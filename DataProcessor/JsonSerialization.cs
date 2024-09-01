using DataProcessor;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
namespace DataProcessor
{
    public class JsonSerialization
    {

        //This is by using system.text.json we can do another example using netwonsoft.json
        public void Serializer()
        {
            string jsonString = @"
                                {
                                    ""success"": true,
                                    ""message"": ""This is a message from our json data"",
                                    ""data"": [{
                                            ""name"":""Pratik""
                                        }]
                                }";

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true, //This will properly format the output of data
                PropertyNameCaseInsensitive = true, // the output will be mapped to the related calss if there is one irrespective to the word casing
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // this will ignore the characters that will affect the 
            };

            //While we deserialize we convert this json object into an object
            object? json = JsonSerializer.Deserialize<object>(jsonString);
            //when we serialize we convert the deserialized object into an string
            string jsonStr = JsonSerializer.Serialize(json);

            //we can access the member using jsondocument with the jsonelement

            JsonDocument doc = JsonDocument.Parse(jsonStr); // first we parse to get the json from the string value
            JsonElement element = doc.RootElement;  //we can get the root element by using rootelement to jsondocument and get a jsonelement type
            string messsage = element.GetProperty("message").ToString(); // we can extract message using get property method
            Console.WriteLine(messsage);    
            //to get the array first we should be sure that an array will exist in the json string

            var array = element.GetProperty("data"); // this will return an exception if the data does not exist.

            //To check we can do jsonelement.valuekind which can check if it is an array type, string type , object type or other
            if(array.ValueKind == JsonValueKind.Array)
            {
                Console.WriteLine("This is a type of array");
            }
            
            //to be super safe we can do this while checking for array 
            if(element.TryGetProperty("data", out JsonElement dataElement) && dataElement.ValueKind == JsonValueKind.Array )
            {
                Console.WriteLine("This is an array");
                if (dataElement.GetArrayLength() > 0)
                {
                    Console.WriteLine($"This is an array of length {dataElement.GetArrayLength()}");
                }
                else
                {
                    Console.WriteLine("This is an empty array");
                }
            }
        }
    }
}

//in program.cs
//JsonSerialization jsonSerialization = new JsonSerialization();
//jsonSerialization.Serializer();
