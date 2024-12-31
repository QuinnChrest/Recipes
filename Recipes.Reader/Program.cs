using OpenAI.Chat;
using Tesseract;

try
{
    var base_folder = Environment.GetEnvironmentVariable("BASE_FOLDER") ?? "C:\\Deploy\\Recipes";
    var output_folder = Path.Combine(base_folder, "OUTPUT");
    Directory.CreateDirectory(output_folder);

    var openai_api_key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
    if (string.IsNullOrEmpty(openai_api_key))
    {
        Console.WriteLine("Invalid OpenAI API key provided.");
        return;
    }

    var files = Directory.GetFiles(base_folder);

    foreach (var file in files)
    {
        Console.WriteLine($"Processing: {file}");

        if (string.IsNullOrEmpty(file) || !File.Exists(file))
        {
            Console.WriteLine($"No file was found at: {file}");
            return;
        }

        using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
        using (var img = Pix.LoadFromFile(file))
        using (var page = engine.Process(img))
        {
            var text = page.GetText();
            var client = new ChatClient("gpt-4o-mini", openai_api_key);
            var completion = client.CompleteChat($"This is a recipe that I have scanned in, could you return it back to me with markdown formatting. I only want the recipe in the result because I will ingest that data: \n {text}");

            var output_file_path = Path.Combine(output_folder, $"{Path.GetFileNameWithoutExtension(file)}.txt");
            File.WriteAllText(output_file_path, completion.Value.Content[0].Text);
            Console.WriteLine($"GPT outputed to: {output_file_path}");
        }
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}