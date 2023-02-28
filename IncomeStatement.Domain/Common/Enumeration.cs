using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Common
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }
        public Guid Id { get; private set; }

        protected Enumeration(Guid id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public static T GetById<T>(Guid id) where T : Enumeration
        {
            var enumerations = GetAll<T>();
            foreach (var enumeration in enumerations)
                if (enumeration.Id == id) 
                    return enumeration;

            throw new Exception($"Enumeration of type {typeof(T)} with id {id}, could not be found");
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration otherValue)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object? other) => Id.CompareTo(((Enumeration)other).Id);

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
