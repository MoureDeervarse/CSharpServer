using System.Collections.Generic;
using WebServer.Models;

namespace WebServer.Repositories
{
    public interface IExampleRepository
    {
        IEnumerable<ExampleModel> GetAll();
        ExampleModel GetById(int id);
        void Add(ExampleModel model);
        // ...other methods...
    }
}
