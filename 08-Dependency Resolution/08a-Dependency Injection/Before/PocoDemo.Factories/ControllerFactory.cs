using System.Web.Http;

namespace PocoDemo.Factories
{
    public abstract class ControllerFactory
    {
        public abstract ApiController GetController(string data);
    }
}
