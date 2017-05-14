using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Services
{
    public interface IService<out T> where T : class
    {
        IEnumerable<T> ReadAll();
    }
}
