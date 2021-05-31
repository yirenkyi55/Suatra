using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Suatra.Fixtures
{
    public class LoadDataAttribute : DataAttribute
    {
        public readonly string _fileName;

        private readonly string _section;

        public LoadDataAttribute(string section)
        {
            _fileName = "recordData.json";
            _section = section;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            // We construct a path to the file
            var path = Path.IsPathRooted(_fileName) ? _fileName :
                Path.GetRelativePath(Directory.GetCurrentDirectory(), _fileName);

            // if the file does not exists, we return exception
            if (!File.Exists(path))
            {
                throw new ArgumentException($"File Not Found: {path}");
            }

            // We read the file data
            var fileData = File.ReadAllText(_fileName);

            // If the section is empty or null we return  string array of all the fileData
            if (string.IsNullOrEmpty(_section))
            {
                return JsonConvert.DeserializeObject<List<string[]>>(fileData);
            }

            var allRecordsFromFile = JObject.Parse(fileData);
            var sectionRecords = allRecordsFromFile[_section];

            // we return a list of the records converted to the object type found in the parameter method
            return new List<object[]>
            {
                new[]{sectionRecords.ToObject(testMethod.GetParameters().First().ParameterType)}
            };
        }
    }
}
