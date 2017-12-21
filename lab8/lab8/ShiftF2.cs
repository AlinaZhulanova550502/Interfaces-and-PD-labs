using EventHook;

namespace lab8
{
    class ShiftF2
    {
        private bool _shiftPressed;
        private bool _somethingElse;

        private const string LShiftKeyName = "LeftShift";
        private const string RShiftKeyName = "RightShift";
        private const string F2 = "VolumeDown";

        public void AnalyseEvent(KeyData keyData, Form1 form1)
        {
            var isKeyDownEvent = keyData.EventType.ToString().Equals("down");

            switch (keyData.Keyname)
            {
                case RShiftKeyName:
                case LShiftKeyName:
                    _somethingElse = false;
                    _shiftPressed = isKeyDownEvent;
                    break;

                case F2:
                    if (_shiftPressed && isKeyDownEvent && !_somethingElse)
                    {
                        _shiftPressed = false;
                        form1.IsVisible = !form1.IsVisible;
                    }
                    break;

                default:
                    _somethingElse = true;
                    break;
            }
        }
    }
}
