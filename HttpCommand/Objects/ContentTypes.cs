

namespace HttpCommand{
    /// <summary>
    /// Types of content types a request can have
    /// </summary>
    public class ContentType{
        private ContentType(string value){Value=value;}
        /// <summary>
        /// 
        /// </summary>
        public string Value{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public static ContentType PostForm{get{return new ContentType("application/x-www-form-urlencoded");}}
        /// <summary>
        /// 
        /// </summary>
        public static ContentType GetForm{get{return new ContentType("");}}
        /// <summary>
        /// 
        /// </summary>
        public static ContentType Json{get{return new ContentType("application/json");}}
        /// <summary>
        /// 
        /// </summary>
        public static ContentType FormData{get{return new ContentType("multipart/form-data");}}
        /// <summary>
        /// 
        /// </summary>
        public static ContentType TextHTML{get{return new ContentType("text/html");}}
    }
}
