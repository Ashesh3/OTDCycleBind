using System;
using System.Diagnostics;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.DependencyInjection;
using OpenTabletDriver.Plugin.Platform.Keyboard;
using OpenTabletDriver.Plugin.Tablet;

namespace CycleBind
{
    [PluginName("Cycle Bind")]
    public class CycleBind : IStateBinding, IBinding
    {
        private IList<string> _keys = Array.Empty<string>();
        private string _keysString = string.Empty;

        [Property("Keys")]
        public string Keys
        {
            set
            {
                _keysString = value;
                _keys = ParseKeys(Keys);
            }
            get => _keysString;
        }

        private static int currentKeyIndex = 0;

        [Resolved]
        public IVirtualKeyboard Keyboard { set; get; }

        public void Press(TabletReference tablet, IDeviceReport report)
        {
            currentKeyIndex++;

            if (_keys.Count == 0) return;

            if (currentKeyIndex >= _keys.Count || currentKeyIndex < 0) currentKeyIndex = 0;

            Keyboard.Press(_keys[currentKeyIndex]);
            Log.Debug("CycleBind", $"Pressed {_keys[currentKeyIndex]}");
        }

        public void Release(TabletReference tablet, IDeviceReport report)
        {
            if (_keys.Count == 0) return;

            if (currentKeyIndex >= _keys.Count || currentKeyIndex < 0) currentKeyIndex = 0;

            Keyboard.Release(_keys[currentKeyIndex]);
            Log.Debug("CycleBind", $"Released {_keys[currentKeyIndex]}");
        }

        private IList<string> ParseKeys(string str)
        {
            var newKeys = str.Split('+', StringSplitOptions.TrimEntries);
            return newKeys.All(k => Keyboard.SupportedKeys.Contains(k)) ? newKeys :
                throw new NotSupportedException($"The keybinding combination ({str}) is not supported.");
        }

    }
}