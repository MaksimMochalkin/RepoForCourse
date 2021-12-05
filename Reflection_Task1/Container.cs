using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Task1
{
    public class Container
    {
        private readonly List<Assembly> asmLIst = new List<Assembly>();
        private readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();

        public void AddAssembly(Assembly assembly)
        {
            var asm = Assembly.LoadFrom(assembly.Location);
            var types = asm.GetTypes().ToList();
            foreach (var t in types)
            {
                AddType(t);
            }
            asmLIst.Add(asm);
        }

        public void AddType(Type type)
        {
            types.Add(type, type);
        }

        public void AddType(Type type, Type baseType)
        {
            if (types.ContainsKey(baseType))
            {
                throw new InvalidOperationException("blabla");
            }

            types[baseType] = type;
        }

        public T Get<T>()
        {
            object instance;
            var receivedType = typeof(T);
            var list = new List<object>();
            if (receivedType.IsClass)
            {
                var customAtributes = receivedType.GetCustomAttributes().ToList();
                var properties = receivedType.GetProperties().ToList();
                var ctors = receivedType.GetConstructors().ToList();
                foreach (var atr in customAtributes)
                {
                    var atrType = (Type)atr.TypeId;
                    if (atrType.Name == "ExportAttribute")
                    {
                        instance = Activator.CreateInstance(receivedType);
                        return (T)instance;
                    }

                    if (atrType.Name == "ImportConstructorAttribute")
                    {

                        foreach (var ctor in ctors)
                        {
                            var parameters = ctor.GetParameters();
                            foreach (var param in parameters)
                            {
                                if (asmLIst.Count != 0)
                                {
                                    var type = asmLIst[0].GetTypes()
                                        .Where(type => param.ParameterType.IsAssignableFrom(type) && !type.IsInterface).FirstOrDefault();
                                    list.Add(type);
                                }
                                else
                                {
                                    types.TryGetValue(param.ParameterType, out var type);
                                    list.Add(type);
                                }

                            }
                        }
                        var customerDAL = Activator.CreateInstance((Type)list[0]);
                        var loger = Activator.CreateInstance((Type)list[1]);
                        instance = Activator.CreateInstance(receivedType, customerDAL, loger);
                        return (T)instance;
                    }
                }

                if (properties.Count != 0)
                {
                    foreach (var property in properties)
                    {
                        if (asmLIst.Count != 0)
                        {
                            var type = asmLIst[0].GetTypes()
                                .Where(type => property.PropertyType.IsAssignableFrom(type) && !type.IsInterface).FirstOrDefault();
                            list.Add(type);
                        }
                        else
                        {
                            types.TryGetValue(property.PropertyType, out var type);
                            list.Add(type);
                        }

                    }
                    var customerDAL = Activator.CreateInstance((Type)list[0]);
                    var loger = Activator.CreateInstance((Type)list[1]);
                    instance = Activator.CreateInstance(receivedType);
                    properties[0].SetValue(instance, customerDAL);
                    properties[1].SetValue(instance, loger);

                    return (T)instance;
                }
            }
            else if (receivedType.IsInterface)
            {
                if (asmLIst.Count != 0)
                {
                    var type = asmLIst[0].GetTypes()
                        .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface).FirstOrDefault();
                    instance = Activator.CreateInstance(type);
                    return (T)instance;
                }
                else
                {
                    types.TryGetValue(receivedType, out var type);
                    instance = Activator.CreateInstance(type);
                    return (T)instance;
                }

            }

            throw new Exception("blabla");
        }
    }
}