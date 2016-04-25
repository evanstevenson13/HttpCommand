

namespace HttpCommand{
    //public sealed class ContentType{
    //    public const string PostForm = "application/x-www-form-urlencoded";
    //    //public const string GetForm = "";
    //    public const string Json = "application/json"; //"application/json";
    //    public const string FormData = "multipart/form-data";
    //    public const string TextHTML = "text/html";
    //}

    public class ContentType{
        private ContentType(string value){Value=value;}
        public string Value{get;set;}
        public static ContentType PostForm{get{return new ContentType("application/x-www-form-urlencoded");}}
        public static ContentType GetForm{get{return new ContentType("");}}
        public static ContentType Json{get{return new ContentType("application/json");}}
        public static ContentType FormData{get{return new ContentType("multipart/form-data");}}
        public static ContentType TextHTML{get{return new ContentType("text/html");}}
    }
}
