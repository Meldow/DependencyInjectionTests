namespace GetServicesByInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    public interface IServices : IServicesExecuter
    {
    }
    
    public interface IServicesExecuter 
    {
        Task Execute();
    }

    public class Services : IServices
    {
        private readonly IEnumerable<IServicesExecuter> servicesToExecute;

        public Services(IServiceProvider container)
        {
            Console.WriteLine("Ctor: Services");
            this.servicesToExecute = container.GetServices<IServicesExecuter>();
            Console.WriteLine("end");
        }

        public Task Execute()
        {
            Console.WriteLine("Execute: Service");
            return Task.WhenAll(
                this.servicesToExecute
                    .AsParallel()
                    .Select(service => service.Execute()));
        }
    }

    public class ConcreteServiceA : IServicesExecuter
    {
        public ConcreteServiceA(IServiceProvider container)
        {
            Console.WriteLine("Ctor: ConcreteServiceA");
        }
        
        public Task Execute()
        {
            Console.WriteLine("Execute: ConcreteServiceA");
            return Task.CompletedTask;
        }
    }

    public class ConcreteServiceB : IServicesExecuter
    {
        public ConcreteServiceB(IServiceProvider container)
        {
            Console.WriteLine("Ctor: ConcreteServiceB");
        }

        public Task Execute()
        {
            Console.WriteLine("Execute: ConcreteServiceB");
            return Task.CompletedTask;
        }
    }

    public class ConcreteServiceC : IServicesExecuter
    {
        public ConcreteServiceC(IServiceProvider container)
        {
            Console.WriteLine("Ctor: ConcreteServiceC");
        }

        public Task Execute()
        {
            Console.WriteLine("Execute: ConcreteServiceC");
            return Task.CompletedTask;
        }
    }
}