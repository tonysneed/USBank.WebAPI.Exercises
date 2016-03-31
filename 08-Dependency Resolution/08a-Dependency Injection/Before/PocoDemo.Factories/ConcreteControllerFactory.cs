using System;
using System.Collections.Generic;
using System.Web.Http;
using V1Controllers = PocoDemo.Controllers.v1.Controllers;
using V2Controllers = PocoDemo.Controllers.v2.Controllers;

namespace PocoDemo.Factories
{
    public class ConcreteControllerFactory : ControllerFactory
    {
        private readonly Dictionary<string, ApiController> _controllers;

        public ConcreteControllerFactory(Dictionary<string, ApiController> controllers)
        {
            _controllers = controllers;
        }

        public override ApiController GetController(string data)
        {
            if (data == "foo")
            {
                //return new V1Controllers.CustomersController(null);
                return _controllers["controller1"];
            }
            if (data == "bar")
            {
                //return new V2Controllers.CustomersController(null);
                return _controllers["controller2"];
            }
            return null;
        }
    }
}
