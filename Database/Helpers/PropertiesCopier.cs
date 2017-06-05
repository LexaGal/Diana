using System.Linq;
namespace Database.Helpers
{
    public static class PropertiesCopier
    {
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties()
                .Where(x => x.CanRead && !x.GetGetMethod().IsVirtual).ToList();//определение свойства объекта, из которого можно записать

            var destProps = typeof(TU).GetProperties()
                .Where(x => x.CanWrite)
                .ToList();//свойства объекта. в который мы записываем

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);//установка нового значения свойства
                }
            }
        }
    }
}