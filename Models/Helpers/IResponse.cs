namespace Models.Helpers
{
    internal interface IResponse
    {
        string Message { get; set; }
        bool Success { get; set; }
    }
}
