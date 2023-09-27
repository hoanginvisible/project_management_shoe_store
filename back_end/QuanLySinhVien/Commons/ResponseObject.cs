namespace QuanLyCuaHangBanGiay.Commons
{
    public class ResponseObject
    {
        public bool? IsSuccess { get; set; } = false;
        public object? Data { get; set; }
        public string? Message { get; set; }

        public ResponseObject(object? data, string? message)
        {
            ProcessReponseObject(data, message);
        }
        
        public ResponseObject(string? message)
        {
            ProcessReponseObject(null, message);
        }
        

        public void ProcessReponseObject(object? obj, string? mess)
        {
            if (obj != null)
            {
                IsSuccess = true;
                Data = obj;
            }

            this.Message = mess;
        }
    }
}