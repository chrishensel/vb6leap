// This file is part of vb6leap.
// 
// vb6leap is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// vb6leap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with vb6leap.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.ComponentModel;

namespace VB6leap.Core.Collections
{
    /// <summary>
    /// Defines methods for a simple property bag, that is, a simple dictionary holding anything.
    /// </summary>
    public interface IPropertyBag : INotifyPropertyChanged, IEnumerable<string>
    {
        /// <summary>
        /// Retrieves a value by its key, or returns a default value if the key wasn't found.
        /// </summary>
        /// <typeparam name="T">The desired type of the item to get.</typeparam>
        /// <param name="key">The name of the item to get.</param>
        /// <param name="defaultValue">The value to return if the item doesn't exist.</param>
        /// <returns></returns>
        T Get<T>(string key, T defaultValue);
        /// <summary>
        /// Sets the value of a key.
        /// </summary>
        /// <param name="key">The name of the item to set.</param>
        /// <param name="value">The value to set.</param>
        void Set(string key, object value);
    }
}
