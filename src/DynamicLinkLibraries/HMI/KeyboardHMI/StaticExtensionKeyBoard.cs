using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace KeyboardHMI
{
    public static class StaticExtensionKeyBoard
    {
        static Dictionary<Key, string> keyString = new Dictionary<Key, string>();

        static Dictionary<uint, InputControlAttribute> intAttr = new ();

        static Dictionary<InputControlAttribute, uint> attrInt = new();

        static Dictionary<string, Key> stringKey = new Dictionary<string, Key>();

        static Dictionary<uint, Key> uiKey = new Dictionary<uint, Key>();
        static Dictionary<Key, uint> keyUI = new();




        static StaticExtensionKeyBoard()
        {

            foreach (var key in Enum.GetValues<Key>())
            {
                var ui = (uint)key;
                uiKey[ui] = key;
               keyUI[key] = ui;
            }
            foreach (var att in attributes)
            {
                var ui = (uint)att.bit;
                intAttr[ui] = att;
                attrInt[att] = ui;

                foreach (var key in Enum.GetValues<Key>())
                {

                }
            }

        }

        static InputControlAttribute[] attributes = [
        new () {name = "anyKey", displayName = "Any Key", layout = "AnyKey", bit = 1, sizeInBits = kSizeInBits, synthetic = true},
        new () {name = "escape", displayName = "Escape", layout = "Key", usages = new string[] { "Back", "Cancel" }, bit = (int)Key.Escape},
        new () {name = "space", displayName = "Space", layout = "Key", bit = (int)Key.Space},
        new () {name = "enter", displayName = "Enter", layout = "Key", usage = "Submit", bit = (int)Key.Enter},
        new () {name = "tab", displayName = "Tab", layout = "Key", bit = (int)Key.Tab},
        new () {name = "backquote", displayName = "`", layout = "Key", bit = (int)Key.Backquote},
        new () {name = "quote", displayName = "'", layout = "Key", bit = (int)Key.Quote},
        new () {name = "semicolon", displayName = ";", layout = "Key", bit = (int)Key.Semicolon},
        new () {name = "comma", displayName = ",", layout = "Key", bit = (int)Key.Comma},
        new () {name = "period", displayName = ".", layout = "Key", bit = (int)Key.Period},
        new () {name = "slash", displayName = "/", layout = "Key", bit = (int)Key.Slash},
        new () {name = "backslash", displayName = "\\", layout = "Key", bit = (int)Key.Backslash},
        new () {name = "leftBracket", displayName = "[", layout = "Key", bit = (int)Key.LeftBracket},
        new () {name = "rightBracket", displayName = "},", layout = "Key", bit = (int)Key.RightBracket},
        new () {name = "minus", displayName = "-", layout = "Key", bit = (int)Key.Minus},
        new () {name = "equals", displayName = "=", layout = "Key", bit = (int)Key.Equals},
        new () {name = "upArrow", displayName = "Up Arrow", layout = "Key", bit = (int)Key.UpArrow},
        new () {name = "downArrow", displayName = "Down Arrow", layout = "Key", bit = (int)Key.DownArrow},
        new () {name = "leftArrow", displayName = "Left Arrow", layout = "Key", bit = (int)Key.LeftArrow},
        new () {name = "rightArrow", displayName = "Right Arrow", layout = "Key", bit = (int)Key.RightArrow},
        new () {name = "a", displayName = "A", layout = "Key", bit = (int)Key.A},
        new () {name = "b", displayName = "B", layout = "Key", bit = (int)Key.B},
        new () {name = "c", displayName = "C", layout = "Key", bit = (int)Key.C},
        new () {name = "d", displayName = "D", layout = "Key", bit = (int)Key.D},
        new () {name = "e", displayName = "E", layout = "Key", bit = (int)Key.E},
        new () {name = "f", displayName = "F", layout = "Key", bit = (int)Key.F},
        new () {name = "g", displayName = "G", layout = "Key", bit = (int)Key.G},
        new () {name = "h", displayName = "H", layout = "Key", bit = (int)Key.H},
        new () {name = "i", displayName = "I", layout = "Key", bit = (int)Key.I},
        new () {name = "j", displayName = "J", layout = "Key", bit = (int)Key.J},
        new () {name = "k", displayName = "K", layout = "Key", bit = (int)Key.K},
        new () {name = "l", displayName = "L", layout = "Key", bit = (int)Key.L},
        new () {name = "m", displayName = "M", layout = "Key", bit = (int)Key.M},
        new () {name = "n", displayName = "N", layout = "Key", bit = (int)Key.N},
        new () {name = "o", displayName = "O", layout = "Key", bit = (int)Key.O},
        new () {name = "p", displayName = "P", layout = "Key", bit = (int)Key.P},
        new () {name = "q", displayName = "Q", layout = "Key", bit = (int)Key.Q},
        new () {name = "r", displayName = "R", layout = "Key", bit = (int)Key.R},
        new () {name = "s", displayName = "S", layout = "Key", bit = (int)Key.S},
        new () {name = "t", displayName = "T", layout = "Key", bit = (int)Key.T},
        new () {name = "u", displayName = "U", layout = "Key", bit = (int)Key.U},
        new () {name = "v", displayName = "V", layout = "Key", bit = (int)Key.V},
        new () {name = "w", displayName = "W", layout = "Key", bit = (int)Key.W},
        new () {name = "x", displayName = "X", layout = "Key", bit = (int)Key.X},
        new () {name = "y", displayName = "Y", layout = "Key", bit = (int)Key.Y},
        new () {name = "z", displayName = "Z", layout = "Key", bit = (int)Key.Z},
        new () {name = "1", displayName = "1", layout = "Key", bit = (int)Key.Digit1},
        new () {name = "2", displayName = "2", layout = "Key", bit = (int)Key.Digit2},
        new () {name = "3", displayName = "3", layout = "Key", bit = (int)Key.Digit3},
        new () {name = "4", displayName = "4", layout = "Key", bit = (int)Key.Digit4},
        new () {name = "5", displayName = "5", layout = "Key", bit = (int)Key.Digit5},
        new () {name = "6", displayName = "6", layout = "Key", bit = (int)Key.Digit6},
        new () {name = "7", displayName = "7", layout = "Key", bit = (int)Key.Digit7},
        new () {name = "8", displayName = "8", layout = "Key", bit = (int)Key.Digit8},
        new () {name = "9", displayName = "9", layout = "Key", bit = (int)Key.Digit9},
        new () {name = "0", displayName = "0", layout = "Key", bit = (int)Key.Digit0},
        new () {name = "leftShift", displayName = "Left Shift", layout = "Key", usage = "Modifier", bit = (int)Key.LeftShift},
        new () {name = "rightShift", displayName = "Right Shift", layout = "Key", usage = "Modifier", bit = (int)Key.RightShift},
        new () {name = "shift", displayName = "Shift", layout = "DiscreteButton", usage = "Modifier", bit = (int)Key.LeftShift, sizeInBits = 2, synthetic = true, parameters = "minValue=1,maxValue=3,writeMode=1"},
        new () {name = "leftAlt", displayName = "Left Alt", layout = "Key", usage = "Modifier", bit = (int)Key.LeftAlt},
        new () {name = "rightAlt", displayName = "Right Alt", layout = "Key", usage = "Modifier", bit = (int)Key.RightAlt, alias = "AltGr"},
        new () {name = "alt", displayName = "Alt", layout = "DiscreteButton", usage = "Modifier", bit = (int)Key.LeftAlt, sizeInBits = 2, synthetic = true, parameters = "minValue=1,maxValue=3,writeMode=1"},
        new () {name = "leftCtrl", displayName = "Left Control", layout = "Key", usage = "Modifier", bit = (int)Key.LeftCtrl},
        new () {name = "rightCtrl", displayName = "Right Control", layout = "Key", usage = "Modifier", bit = (int)Key.RightCtrl},
        new () {name = "ctrl", displayName = "Control", layout = "DiscreteButton", usage = "Modifier", bit = (int)Key.LeftCtrl, sizeInBits = 2, synthetic = true, parameters = "minValue=1,maxValue=3,writeMode=1"},
        new () {name = "leftMeta", displayName = "Left System", layout = "Key", usage = "Modifier", bit = (int)Key.LeftMeta, aliases = new string[]  { "LeftWindows", "LeftApple", "LeftCommand" }},
        new () {name = "rightMeta", displayName = "Right System", layout = "Key", usage = "Modifier", bit = (int)Key.RightMeta, aliases = new string[]  { "RightWindows", "RightApple", "RightCommand" }},
        new () {name = "contextMenu", displayName = "Context Menu", layout = "Key", usage = "Modifier", bit = (int)Key.ContextMenu},
        new () {name = "backspace", displayName = "Backspace", layout = "Key", bit = (int)Key.Backspace},
        new () {name = "pageDown", displayName = "Page Down", layout = "Key", bit = (int)Key.PageDown},
        new () {name = "pageUp", displayName = "Page Up", layout = "Key", bit = (int)Key.PageUp},
        new () {name = "home", displayName = "Home", layout = "Key", bit = (int)Key.Home},
        new () {name = "end", displayName = "End", layout = "Key", bit = (int)Key.End},
        new () {name = "insert", displayName = "Insert", layout = "Key", bit = (int)Key.Insert},
        new () {name = "delete", displayName = "Delete", layout = "Key", bit = (int)Key.Delete},
        new () {name = "capsLock", displayName = "Caps Lock", layout = "Key", bit = (int)Key.CapsLock},
        new () {name = "numLock", displayName = "Num Lock", layout = "Key", bit = (int)Key.NumLock},
        new () {name = "printScreen", displayName = "Print Screen", layout = "Key", bit = (int)Key.PrintScreen},
        new () {name = "scrollLock", displayName = "Scroll Lock", layout = "Key", bit = (int)Key.ScrollLock},
        new () {name = "pause", displayName = "Pause/Break", layout = "Key", bit = (int)Key.Pause},
        new () {name = "numpadEnter", displayName = "Numpad Enter", layout = "Key", bit = (int)Key.NumpadEnter},
        new () {name = "numpadDivide", displayName = "Numpad /", layout = "Key", bit = (int)Key.NumpadDivide},
        new () {name = "numpadMultiply", displayName = "Numpad *", layout = "Key", bit = (int)Key.NumpadMultiply},
        new () {name = "numpadPlus", displayName = "Numpad +", layout = "Key", bit = (int)Key.NumpadPlus},
        new () {name = "numpadMinus", displayName = "Numpad -", layout = "Key", bit = (int)Key.NumpadMinus},
        new () {name = "numpadPeriod", displayName = "Numpad .", layout = "Key", bit = (int)Key.NumpadPeriod},
        new () {name = "numpadEquals", displayName = "Numpad =", layout = "Key", bit = (int)Key.NumpadEquals},
        new () {name = "numpad1", displayName = "Numpad 1", layout = "Key", bit = (int)Key.Numpad1},
        new () {name = "numpad2", displayName = "Numpad 2", layout = "Key", bit = (int)Key.Numpad2},
        new () {name = "numpad3", displayName = "Numpad 3", layout = "Key", bit = (int)Key.Numpad3},
        new () {name = "numpad4", displayName = "Numpad 4", layout = "Key", bit = (int)Key.Numpad4},
        new () {name = "numpad5", displayName = "Numpad 5", layout = "Key", bit = (int)Key.Numpad5},
        new () {name = "numpad6", displayName = "Numpad 6", layout = "Key", bit = (int)Key.Numpad6},
        new () {name = "numpad7", displayName = "Numpad 7", layout = "Key", bit = (int)Key.Numpad7},
        new () {name = "numpad8", displayName = "Numpad 8", layout = "Key", bit = (int)Key.Numpad8},
        new () {name = "numpad9", displayName = "Numpad 9", layout = "Key", bit = (int)Key.Numpad9},
        new () {name = "numpad0", displayName = "Numpad 0", layout = "Key", bit = (int)Key.Numpad0},
        new () {name = "f1", displayName = "F1", layout = "Key", bit = (int)Key.F1},
        new () {name = "f2", displayName = "F2", layout = "Key", bit = (int)Key.F2},
        new () {name = "f3", displayName = "F3", layout = "Key", bit = (int)Key.F3},
        new () {name = "f4", displayName = "F4", layout = "Key", bit = (int)Key.F4},
        new () {name = "f5", displayName = "F5", layout = "Key", bit = (int)Key.F5},
        new () {name = "f6", displayName = "F6", layout = "Key", bit = (int)Key.F6},
        new () {name = "f7", displayName = "F7", layout = "Key", bit = (int)Key.F7},
        new () {name = "f8", displayName = "F8", layout = "Key", bit = (int)Key.F8},
        new () {name = "f9", displayName = "F9", layout = "Key", bit = (int)Key.F9},
        new () {name = "f10", displayName = "F10", layout = "Key", bit = (int)Key.F10},
        new () {name = "f11", displayName = "F11", layout = "Key", bit = (int)Key.F11},
        new () {name = "f12", displayName = "F12", layout = "Key", bit = (int)Key.F12},
        new () {name = "OEM1", layout = "Key", bit = (int)Key.OEM1},
        new () {name = "OEM2", layout = "Key", bit = (int)Key.OEM2},
        new () {name = "OEM3", layout = "Key", bit = (int)Key.OEM3},
        new () {name = "OEM4", layout = "Key", bit = (int)Key.OEM4},
        new () {name = "OEM5", layout = "Key", bit = (int)Key.OEM5},
        new () {name = "f13", displayName = "F13", layout = "Key", bit = (int)Key.F13},
        new () {name = "f14", displayName = "F14", layout = "Key", bit = (int)Key.F14},
        new () {name = "f15", displayName = "F15", layout = "Key", bit = (int)Key.F15},
        new () {name = "f16", displayName = "F16", layout = "Key", bit = (int)Key.F16},
        new () {name = "f17", displayName = "F17", layout = "Key", bit = (int)Key.F17},
        new () {name = "f18", displayName = "F18", layout = "Key", bit = (int)Key.F18},
        new () {name = "f19", displayName = "F19", layout = "Key", bit = (int)Key.F19},
        new () {name = "f20", displayName = "F20", layout = "Key", bit = (int)Key.F20},
        new () {name = "f21", displayName = "F21", layout = "Key", bit = (int)Key.F21},
        new () {name = "f22", displayName = "F22", layout = "Key", bit = (int)Key.F22},
        new () {name = "f23", displayName = "F23", layout = "Key", bit = (int)Key.F23},
        new () {name = "f24", displayName = "F24", layout = "Key", bit = (int)Key.F24},
        new () {name = "mediaPlayPause", displayName = "MediaPlayPause", layout = "Key", bit = (int)Key.MediaPlayPause},
        new () {name = "mediaRewind", displayName = "MediaRewind", layout = "Key", bit = (int)Key.MediaRewind},
        new () {name = "mediaForward", displayName = "MediaForward", layout = "Key", bit = (int)Key.MediaForward},
      //  new () {name = "IMESelected", layout = "Button", bit = (int)KeyEx.RemappedIMESelected, synthetic = true}, // Use the last bit to hold IME selected state.
      //  new () {name = "IMESelectedObsoleteKey", layout = "Key", bit = (int)KeyEx.RemappedIMESelected, synthetic = true}
        ];

        public static FourCC Format => new FourCC('K', 'E', 'Y', 'S');

        private const int kSizeInBits = 500;
        internal const int kSizeInBytes = (kSizeInBits + 7) / 8;

        public static InputControlAttribute[] Attributes => attributes;

    }
}