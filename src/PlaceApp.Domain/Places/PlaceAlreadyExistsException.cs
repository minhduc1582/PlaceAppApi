using Volo.Abp;

namespace PlaceApp.Places
{
    public class PlaceAlreadyExistsException : BusinessException
    {
        public PlaceAlreadyExistsException(string name)
            : base(PlaceAppDomainErrorCodes.PlaceAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
