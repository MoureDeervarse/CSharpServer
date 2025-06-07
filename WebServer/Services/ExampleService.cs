using WebServer.Models;
using WebServer.Repositories;
using System.Collections.Generic;

namespace WebServer.Services
{
    public class ExampleService
    {
        private readonly IExampleRepository _repository;

        public ExampleService(IExampleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ExampleModel> GetAllExamples()
        {
            return _repository.GetAll();
        }
    }
}
