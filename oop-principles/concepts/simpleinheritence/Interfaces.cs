using System;

namespace simpleinheritence
{
    public interface IReproducible<T> where T : Felidae

    {
        T[] Reproduce(T mate);
    }

}