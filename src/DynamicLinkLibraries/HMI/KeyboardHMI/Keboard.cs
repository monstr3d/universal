namespace KeyboardHMI
{
    public enum Key
    {
        /// <summary>
        /// Invalid key. Does not represent a key on the keyboard and is only used to have a
        /// default for the Key enumeration not represent any specific key.
        /// </summary>
        None,

        // ---- Printable keys ----

        /// <summary>
        /// The <see cref="Keyboard.spaceKey"/>.
        /// </summary>
        Space,

        /// <summary>
        /// The <see cref="Keyboard.enterKey"/>.
        /// </summary>
        Enter,

        /// <summary>
        /// The <see cref="Keyboard.tabKey"/>.
        /// </summary>
        Tab,

        /// <summary>
        /// The <see cref="Keyboard.backquoteKey"/>.
        /// </summary>
        Backquote,

        /// <summary>
        /// The <see cref="Keyboard.quoteKey"/>.
        /// </summary>
        Quote,

        /// <summary>
        /// The <see cref="Keyboard.semicolonKey"/>.
        /// </summary>
        Semicolon,

        /// <summary>
        /// The <see cref="Keyboard.commaKey"/>.
        /// </summary>
        Comma,

        /// <summary>
        /// The <see cref="Keyboard.periodKey"/>.
        /// </summary>
        Period,

        /// <summary>
        /// The <see cref="Keyboard.slashKey"/>.
        /// </summary>
        Slash,

        /// <summary>
        /// The <see cref="Keyboard.backslashKey"/>.
        /// </summary>
        Backslash,

        /// <summary>
        /// The <see cref="Keyboard.leftBracketKey"/>.
        /// </summary>
        LeftBracket,

        /// <summary>
        /// The <see cref="Keyboard.rightBracketKey"/>.
        /// </summary>
        RightBracket,

        /// <summary>
        /// The <see cref="Keyboard.minusKey"/>.
        /// </summary>
        Minus,

        /// <summary>
        /// The <see cref="Keyboard.equalsKey"/>.
        /// </summary>
        Equals,

        /// <summary>
        /// The <see cref="Keyboard.aKey"/>.
        /// </summary>
        A,

        /// <summary>
        /// The <see cref="Keyboard.bKey"/>.
        /// </summary>
        B,

        /// <summary>
        /// The <see cref="Keyboard.cKey"/>.
        /// </summary>
        C,

        /// <summary>
        /// The <see cref="Keyboard.dKey"/>.
        /// </summary>
        D,

        /// <summary>
        /// The <see cref="Keyboard.eKey"/>.
        /// </summary>
        E,

        /// <summary>
        /// The <see cref="Keyboard.fKey"/>.
        /// </summary>
        F,

        /// <summary>
        /// The <see cref="Keyboard.gKey"/>.
        /// </summary>
        G,

        /// <summary>
        /// The <see cref="Keyboard.hKey"/>.
        /// </summary>
        H,

        /// <summary>
        /// The <see cref="Keyboard.iKey"/>.
        /// </summary>
        I,

        /// <summary>
        /// The <see cref="Keyboard.jKey"/>.
        /// </summary>
        J,

        /// <summary>
        /// The <see cref="Keyboard.kKey"/>.
        /// </summary>
        K,

        /// <summary>
        /// The <see cref="Keyboard.lKey"/>.
        /// </summary>
        L,

        /// <summary>
        /// The <see cref="Keyboard.mKey"/>.
        /// </summary>
        M,

        /// <summary>
        /// The <see cref="Keyboard.nKey"/>.
        /// </summary>
        N,

        /// <summary>
        /// The <see cref="Keyboard.oKey"/>.
        /// </summary>
        O,

        /// <summary>
        /// The <see cref="Keyboard.pKey"/>.
        /// </summary>
        P,

        /// <summary>
        /// The <see cref="Keyboard.qKey"/>.
        /// </summary>
        Q,

        /// <summary>
        /// The <see cref="Keyboard.rKey"/>.
        /// </summary>
        R,

        /// <summary>
        /// The <see cref="Keyboard.sKey"/>.
        /// </summary>
        S,

        /// <summary>
        /// The <see cref="Keyboard.tKey"/>.
        /// </summary>
        T,

        /// <summary>
        /// The <see cref="Keyboard.uKey"/>.
        /// </summary>
        U,

        /// <summary>
        /// The <see cref="Keyboard.vKey"/>.
        /// </summary>
        V,

        /// <summary>
        /// The <see cref="Keyboard.wKey"/>.
        /// </summary>
        W,

        /// <summary>
        /// The <see cref="Keyboard.xKey"/>.
        /// </summary>
        X,

        /// <summary>
        /// The <see cref="Keyboard.yKey"/>.
        /// </summary>
        Y,

        /// <summary>
        /// The <see cref="Keyboard.zKey"/>.
        /// </summary>
        Z,

        /// <summary>
        /// The <see cref="Keyboard.digit1Key"/>.
        /// </summary>
        Digit1,

        /// <summary>
        /// The <see cref="Keyboard.digit2Key"/>.
        /// </summary>
        Digit2,

        /// <summary>
        /// The <see cref="Keyboard.digit3Key"/>.
        /// </summary>
        Digit3,

        /// <summary>
        /// The <see cref="Keyboard.digit4Key"/>.
        /// </summary>
        Digit4,

        /// <summary>
        /// The <see cref="Keyboard.digit5Key"/>.
        /// </summary>
        Digit5,

        /// <summary>
        /// The <see cref="Keyboard.digit6Key"/>.
        /// </summary>
        Digit6,

        /// <summary>
        /// The <see cref="Keyboard.digit7Key"/>.
        /// </summary>
        Digit7,

        /// <summary>
        /// The <see cref="Keyboard.digit8Key"/>.
        /// </summary>
        Digit8,

        /// <summary>
        /// The <see cref="Keyboard.digit9Key"/>.
        /// </summary>
        Digit9,

        /// <summary>
        /// The <see cref="Keyboard.digit0Key"/>.
        /// </summary>
        Digit0,

        // ---- Non-printable keys ----

        // NOTE: The left&right variants for shift, ctrl, and alt must be next to each other.

        /// <summary>
        /// The <see cref="Keyboard.leftShiftKey"/>.
        /// </summary>
        LeftShift,

        /// <summary>
        /// The <see cref="Keyboard.rightShiftKey"/>.
        /// </summary>
        RightShift,

        /// <summary>
        /// The <see cref="Keyboard.leftAltKey"/>.
        /// </summary>
        LeftAlt,

        /// <summary>
        /// The <see cref="Keyboard.rightAltKey"/>.
        /// </summary>
        RightAlt,

        /// <summary>
        /// Same as <see cref="RightAlt"/>.
        /// </summary>
        AltGr = RightAlt,

        /// <summary>
        /// The <see cref="Keyboard.leftCtrlKey"/>.
        /// </summary>
        LeftCtrl,

        /// <summary>
        /// The <see cref="Keyboard.rightCtrlKey"/>.
        /// </summary>
        RightCtrl,

        /// <summary>
        /// The <see cref="Keyboard.leftMetaKey"/>.
        /// </summary>
        LeftMeta,

        /// <summary>
        /// The <see cref="Keyboard.rightMetaKey"/>.
        /// </summary>
        RightMeta,

        /// <summary>
        /// Same as <see cref="LeftMeta"/>.
        /// </summary>
        LeftWindows = LeftMeta,

        /// <summary>
        /// Same as <see cref="RightMeta"/>.
        /// </summary>
        RightWindows = RightMeta,

        /// <summary>
        /// Same as <see cref="LeftMeta"/>.
        /// </summary>
        LeftApple = LeftMeta,

        /// <summary>
        /// Same as <see cref="RightMeta"/>.
        /// </summary>
        RightApple = RightMeta,

        /// <summary>
        /// Same as <see cref="LeftMeta"/>.
        /// </summary>
        LeftCommand = LeftMeta,

        /// <summary>
        /// Same as <see cref="RightMeta"/>.
        /// </summary>
        RightCommand = RightMeta,

        /// <summary>
        /// The <see cref="Keyboard.contextMenuKey"/>.
        /// </summary>
        ContextMenu,

        /// <summary>
        /// The <see cref="Keyboard.escapeKey"/>.
        /// </summary>
        Escape,

        /// <summary>
        /// The <see cref="Keyboard.leftArrowKey"/>.
        /// </summary>
        LeftArrow,

        /// <summary>
        /// The <see cref="Keyboard.rightArrowKey"/>.
        /// </summary>
        RightArrow,

        /// <summary>
        /// The <see cref="Keyboard.upArrowKey"/>.
        /// </summary>
        UpArrow,

        /// <summary>
        /// The <see cref="Keyboard.downArrowKey"/>.
        /// </summary>
        DownArrow,

        /// <summary>
        /// The <see cref="Keyboard.backspaceKey"/>.
        /// </summary>
        Backspace,

        /// <summary>
        /// The <see cref="Keyboard.pageDownKey"/>.
        /// </summary>
        PageDown,

        /// <summary>
        /// The <see cref="Keyboard.pageUpKey"/>.
        /// </summary>
        PageUp,

        /// <summary>
        /// The <see cref="Keyboard.homeKey"/>.
        /// </summary>
        Home,

        /// <summary>
        /// The <see cref="Keyboard.endKey"/>.
        /// </summary>
        End,

        /// <summary>
        /// The <see cref="Keyboard.insertKey"/>.
        /// </summary>
        Insert,

        /// <summary>
        /// The <see cref="Keyboard.deleteKey"/>.
        /// </summary>
        Delete,

        /// <summary>
        /// The <see cref="Keyboard.capsLockKey"/>.
        /// </summary>
        CapsLock,

        /// <summary>
        /// The <see cref="Keyboard.numLockKey"/>.
        /// </summary>
        NumLock,

        /// <summary>
        /// The <see cref="Keyboard.printScreenKey"/>.
        /// </summary>
        PrintScreen,

        /// <summary>
        /// The <see cref="Keyboard.scrollLockKey"/>.
        /// </summary>
        ScrollLock,

        /// <summary>
        /// The <see cref="Keyboard.pauseKey"/>.
        /// </summary>
        Pause,

        // ---- Numpad ----
        // NOTE: Numpad layout follows the 18-key numpad layout. Some PC keyboards
        //       have a 17-key numpad layout where the plus key is an elongated key
        //       like the numpad enter key. Be aware that in those layouts the positions
        //       of some of the operator keys are also different. However, we stay
        //       layout neutral here, too, and always use the 18-key blueprint.

        /// <summary>
        /// The <see cref="Keyboard.numpadEnterKey"/>.
        /// </summary>
        NumpadEnter,

        /// <summary>
        /// The <see cref="Keyboard.numpadDivideKey"/>.
        /// </summary>
        NumpadDivide,

        /// <summary>
        /// The <see cref="Keyboard.numpadMultiplyKey"/>.
        /// </summary>
        NumpadMultiply,

        /// <summary>
        /// The <see cref="Keyboard.numpadPlusKey"/>.
        /// </summary>
        NumpadPlus,

        /// <summary>
        /// The <see cref="Keyboard.numpadMinusKey"/>.
        /// </summary>
        NumpadMinus,

        /// <summary>
        /// The <see cref="Keyboard.numpadPeriodKey"/>.
        /// </summary>
        NumpadPeriod,

        /// <summary>
        /// The <see cref="Keyboard.numpadEqualsKey"/>.
        /// </summary>
        NumpadEquals,

        /// <summary>
        /// The <see cref="Keyboard.numpad0Key"/>.
        /// </summary>
        Numpad0,

        /// <summary>
        /// The <see cref="Keyboard.numpad1Key"/>.
        /// </summary>
        Numpad1,

        /// <summary>
        /// The <see cref="Keyboard.numpad2Key"/>.
        /// </summary>
        Numpad2,

        /// <summary>
        /// The <see cref="Keyboard.numpad3Key"/>.
        /// </summary>
        Numpad3,

        /// <summary>
        /// The <see cref="Keyboard.numpad4Key"/>.
        /// </summary>
        Numpad4,

        /// <summary>
        /// The <see cref="Keyboard.numpad5Key"/>.
        /// </summary>
        Numpad5,

        /// <summary>
        /// The <see cref="Keyboard.numpad6Key"/>.
        /// </summary>
        Numpad6,

        /// <summary>
        /// The <see cref="Keyboard.numpad7Key"/>.
        /// </summary>
        Numpad7,

        /// <summary>
        /// The <see cref="Keyboard.numpad8Key"/>.
        /// </summary>
        Numpad8,

        /// <summary>
        /// The <see cref="Keyboard.numpad9Key"/>.
        /// </summary>
        Numpad9,

        /// <summary>
        /// The <see cref="Keyboard.f1Key"/>.
        /// </summary>
        F1,

        /// <summary>
        /// The <see cref="Keyboard.f2Key"/>.
        /// </summary>
        F2,

        /// <summary>
        /// The <see cref="Keyboard.f3Key"/>.
        /// </summary>
        F3,

        /// <summary>
        /// The <see cref="Keyboard.f4Key"/>.
        /// </summary>
        F4,

        /// <summary>
        /// The <see cref="Keyboard.f5Key"/>.
        /// </summary>
        F5,

        /// <summary>
        /// The <see cref="Keyboard.f6Key"/>.
        /// </summary>
        F6,

        /// <summary>
        /// The <see cref="Keyboard.f7Key"/>.
        /// </summary>
        F7,

        /// <summary>
        /// The <see cref="Keyboard.f8Key"/>.
        /// </summary>
        F8,

        /// <summary>
        /// The <see cref="Keyboard.f9Key"/>.
        /// </summary>
        F9,

        /// <summary>
        /// The <see cref="Keyboard.f10Key"/>.
        /// </summary>
        F10,

        /// <summary>
        /// The <see cref="Keyboard.f11Key"/>.
        /// </summary>
        F11,

        /// <summary>
        /// The <see cref="Keyboard.f12Key"/>.
        /// </summary>
        F12,

        // Extra keys that a keyboard may have. We make no guarantees about where
        // they end up on the keyboard (if they are present).

        /// <summary>
        /// The <see cref="Keyboard.oem1Key"/>.
        /// </summary>
        OEM1,

        /// <summary>
        /// The <see cref="Keyboard.oem2Key"/>.
        /// </summary>
        OEM2,

        /// <summary>
        /// The <see cref="Keyboard.oem3Key"/>.
        /// </summary>
        OEM3,

        /// <summary>
        /// The <see cref="Keyboard.oem4Key"/>.
        /// </summary>
        OEM4,

        /// <summary>
        /// The <see cref="Keyboard.oem5Key"/>.
        /// </summary>
        OEM5,

        /// <summary>
        /// Don't use this. This is a dummy key that is only used internally to represent the IME selected state.
        /// Will be removed in the future.
        /// </summary>
        [Obsolete("IMESelected is a dummy key and will be removed in the future. Please use ButtonControl imeSelected")]
        IMESelected,

        /// <summary>
        /// The <see cref="Keyboard.f13Key"/>.
        /// </summary>
        F13,

        /// <summary>
        /// The <see cref="Keyboard.f14Key"/>.
        /// </summary>
        F14,

        /// <summary>
        /// The <see cref="Keyboard.f15Key"/>.
        /// </summary>
        F15,

        /// <summary>
        /// The <see cref="Keyboard.f16Key"/>.
        /// </summary>
        F16,

        /// <summary>
        /// The <see cref="Keyboard.f17Key"/>.
        /// </summary>
        F17,

        /// <summary>
        /// The <see cref="Keyboard.f18Key"/>.
        /// </summary>
        F18,

        /// <summary>
        /// The <see cref="Keyboard.f19Key"/>.
        /// </summary>
        F19,

        /// <summary>
        /// The <see cref="Keyboard.f20Key"/>.
        /// </summary>
        F20,

        /// <summary>
        /// The <see cref="Keyboard.f21Key"/>.
        /// </summary>
        F21,

        /// <summary>
        /// The <see cref="Keyboard.f22Key"/>.
        /// </summary>
        F22,

        /// <summary>
        /// The <see cref="Keyboard.f23Key"/>.
        /// </summary>
        F23,

        /// <summary>
        /// The <see cref="Keyboard.f24Key"/>.
        /// </summary>
        F24,

        /// <summary>
        /// The <see cref="Keyboard.mediaPlayPause"/>.
        /// </summary>
        MediaPlayPause,

        /// <summary>
        /// The <see cref="Keyboard.mediaRewind"/>.
        /// </summary>
        MediaRewind,

        /// <summary>
        /// The <see cref="Keyboard.mediaForward"/>.
        /// </summary>
        MediaForward,

        /// <summary>
        /// Don't use this. This is a dummy key that is only used internally to represent the IME selected state.
        /// Will be removed in the future.
        /// FIXME: This should never have been a Key but rather just an extra button or state on keyboard
        /// Not exactly a key, but binary data sent by the Keyboard to say if IME is being used.
        /// </summary>
        //InternalForIMESelected = 127,
    }

}
