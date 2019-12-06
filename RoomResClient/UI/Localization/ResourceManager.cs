using System.Collections.Generic;

namespace RoomResClient.UI.Localization
{
    public class ResourceManager : IResourceManager
    {
        #region Constructor

        public ResourceManager(Dictionary<string, string> stringResourceValues)
        {
            _stringResourceValues = stringResourceValues;
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