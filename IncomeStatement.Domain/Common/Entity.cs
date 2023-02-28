using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Common
{
    public abstract class Entity<T> : IEquatable<Entity<T>>
    {
        public Entity(T id)
        {
            Id = id;
        }

        public T Id { get; private init; }

        public static bool operator == (Entity<T>? first, Entity<T> second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator != (Entity<T>? first, Entity<T> second)
        {
            return !(first == second);
        }

        public bool Equals(Entity<T>? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return other.Id.Equals(Id);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType()) 
            { 
                return false;
            }

            if (obj is not Entity<T> entity)
            {
                return false;
            }

            return entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
