using System;
using System.Collections.Generic;

namespace calc.Model
{
        /// <summary>
        ///     Стек элементов на основе массива.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class CustomStack<T> where T : ICloneable
        {
            /// <summary>
            ///     Элементы стека
            /// </summary>
            private T[] _array;


            private const int DefaultCapacity = 4;
            static readonly T[] EmptyArray = new T[0];

            /// <summary>
            ///     Конструктор без параметров, создает пустой стек
            /// </summary>
            public CustomStack()
            {
                _array = EmptyArray;
                Count = 0;
            }

            /// <summary>
            ///     Конструктор создает стек заданой величины
            /// </summary>
            /// <param name="capacity">Величина стека, должна быть положительной</param>
            public CustomStack(int capacity)
            {
                if (capacity < 0)
                    throw new ArgumentException("capacity");
                _array = new T[capacity];
                Count = 0;
            }

            /// <summary>
            ///     Кол-во элементов в стеке
            /// </summary>
            public int Count { get; private set; }

            /// <summary>
            ///     Удалить все объекты из стека
            /// </summary>
            public void Clear()
            {
                Array.Clear(_array, 0, Count); // Don't need to doc this but we clear the elements so that the gc can reclaim the references.
                Count = 0;
            }

            /// <summary>
            ///     Проверка, содержится ли заданный объект в стеке
            /// </summary>
            /// <param name="item">Объект для сравнения</param>
            /// <returns>true - содержится в стеке; false -  не содержится в стеке</returns>
            public bool Contains(T item)
            {
                var count = Count;

                var c = EqualityComparer<T>.Default;
                while (count-- > 0)
                {
                    if (item == null)
                    {
                        if (_array[count] == null)
                            return true;
                    }
                    else if (_array[count] != null && c.Equals(_array[count], item))
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            ///     Возвращает первый элемент стека без его удаления. 
            ///     Если стек пустой, то выдаст InvalidOperationException.
            /// </summary>
            /// <returns></returns>
            public T Peek()
            {
                if (Count == 0)
                    throw new InvalidOperationException("CustomStack is empty");
                return _array[Count - 1];
            }

            /// <summary>
            ///     Взять элемент из стека.
            ///     Если стек пустой, то выдаст InvalidOperationException.
            /// </summary>
            /// <returns></returns>
            public T Pop()
            {
                if (Count == 0)
                    throw new InvalidOperationException("CustomStack is empty");
                var item = _array[--Count];
                _array[Count] = default(T);     // Free memory quicker.
                return item;
            }

            /// <summary>
            ///     Добавляем элемент в стек.
            /// </summary>
            /// <param name="item">Элемент для добавления</param>
            public void Push(T item)
            {
                if (Count == _array.Length)
                {
                    var newArray = new T[(_array.Length == 0) ? DefaultCapacity : 2 * _array.Length];
                    Array.Copy(_array, 0, newArray, 0, Count);
                    _array = newArray;
                }
                _array[Count++] = (T) item.Clone();
            }

            /// <summary>
            ///     Преобразовывает стек в массив
            /// </summary>
            /// <returns>Массив элементов из стека</returns>
            public T[] ToArray()
            {
                var objArray = new T[Count];
                var i = 0;
                while (i < Count)
                {
                    objArray[i] = _array[Count - i - 1];
                    i++;
                }
                return objArray;
            }
    }
}