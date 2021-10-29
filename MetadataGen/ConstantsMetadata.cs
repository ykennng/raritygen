using System;
using System.Collections.Generic;
using System.Text;

namespace MetadataGen
{
    public class ConstantsMetadata
    {
        //metadata placeholder variables for existing metadata format in nftmaker
        public const string Background = "Background_name";
        public const string Skin = "Skin_name";
        public const string Head = "Head_name";
        public const string Body = "Body_name";
        public const string Equipment = "Equipment_name";
        public const string Project_name = "Project_name";
        public const string Website_url = "Website_url";
        public const string CopyrightText = "Copyright_text";

        public const string OutputImageLocation = "OutputImageLocation";

        public const string CsvFile = "MetadataAttributes";
    }

    public enum ImageTypeEnum
    {
        PNG
    }
}
