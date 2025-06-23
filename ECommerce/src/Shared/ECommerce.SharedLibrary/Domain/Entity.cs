using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedLibrary.Domain
{
    public abstract class Entity<T> where T: IEquatable<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        protected Entity()
        {
            CreatedDate = DateTime.UtcNow;
            Id = typeof(T) == typeof(Guid) ? (T)(object)Guid.NewGuid() : default!;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            Entity<T> another = (Entity<T>)obj;
            return another.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity<T> left, Entity<T> right) => !(left == right);
    }
}
