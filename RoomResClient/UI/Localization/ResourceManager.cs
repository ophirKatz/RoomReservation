using Shared.Extensions;
using System.Collections.Generic;

namespace RoomResClient.UI.Localization
{
    public class ResourceManager : IResourceManager
    {
        #region Constructor

        public ResourceManager(Dictionary<string, string> stringResourceValues,
            Dictionary<string, string> styles)
        {
            _stringResourceValues = stringResourceValues.CombineWith(styles);
        }

        #endregion

        #region Implementation of IStringResourceManager

        public string this[string path] => _stringResourceValues?[path] ?? string.Empty;

        #endregion

        #region Private Members

        private readonly Dictionary<string, string> _stringResourceValues;

        #endregion
    }
}