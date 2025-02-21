namespace CustomExceptionHandling.BusinessExceptionCustom
{
    public class BusinessException : Exception
    {
        public string MessageBussinessException { get; set; }
        public BusinessException(string message)
        {
            MessageBussinessException = message;
        }
    }
}