using System;

namespace hospital2
{
    public interface IServiceCollection
    {
        void AddDbContext<T>(Func<object, object> value);
        void AddMvc();
    }
}