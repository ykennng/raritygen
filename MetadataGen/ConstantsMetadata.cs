using System;
using System.Collections.Generic;
using System.Text;

namespace MetadataGen
{
    public class ConstantsMetadata
    {
        //metadata placeholder variables for existing metadata format in nftmaker
        public const string Background = "Background_Name";
        public const string Skin = "Skin_Name";
        public const string Head = "Head_Name";
        public const string Body = "Body_Name";
        public const string Equipment = "Equipment_Name";
        public const string Nft_Name = "nft_name";
        public const string Website_url = "Website_Url";
        public const string CopyrightText = "Copyright_Text";
        public const string Project_name = "Project_name";

        public const string Url = @"https://api.nft-maker.io/";
        public const string Upload = @"UploadNft";

        public const string CopyrightTextContent = "Some text here loremmmm";
        public const string WebsiteUrlContent = "fsjal.com.test";
        //public const string ProjectNameContent = "fsjal.com.test";

        public const string nftNamePrefix = "FSJAL";

        public const string OutputImageLocation = "OutputImageLocation";

        public const string CsvFile = "MetadataAttributes";
    }

    public enum ImageTypeEnum
    {
        PNG
    }
}
