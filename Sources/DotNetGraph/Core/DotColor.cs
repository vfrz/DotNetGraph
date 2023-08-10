using System;

namespace DotNetGraph.Core
{
    public struct DotColor : IEquatable<DotColor>
    {
        public byte R, G, B, A;

        public DotColor(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public bool Equals(DotColor other)
        {
            return R == other.R && G == other.G && B == other.B && A == other.A;
        }

        public override bool Equals(object obj)
        {
            return obj is DotColor other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = R.GetHashCode();
                hashCode = (hashCode * 397) ^ G.GetHashCode();
                hashCode = (hashCode * 397) ^ B.GetHashCode();
                hashCode = (hashCode * 397) ^ A.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"[DotColor, R:{R}, G:{G}, B:{B}, A:{A}]";
        }

        public string ToHexString()
        {
            return A == 255 ? $"#{R:X2}{G:X2}{B:X2}" : $"#{R:X2}{G:X2}{B:X2}{A:X2}";
        }

        // X11 colors
        public static DotColor AliceBlue { get; } = new DotColor(240, 248, 255);
        public static DotColor AntiqueWhite { get; } = new DotColor(250, 235, 215);
        public static DotColor Aqua { get; } = new DotColor(0, 255, 255);
        public static DotColor Aquamarine { get; } = new DotColor(127, 255, 212);
        public static DotColor Azure { get; } = new DotColor(240, 255, 255);
        public static DotColor Beige { get; } = new DotColor(245, 245, 220);
        public static DotColor Bisque { get; } = new DotColor(255, 228, 196);
        public static DotColor Black { get; } = new DotColor(0, 0, 0);
        public static DotColor BlanchedAlmond { get; } = new DotColor(255, 235, 205);
        public static DotColor Blue { get; } = new DotColor(0, 0, 255);
        public static DotColor BlueViolet { get; } = new DotColor(138, 43, 226);
        public static DotColor Brown { get; } = new DotColor(165, 42, 42);
        public static DotColor Burlywood { get; } = new DotColor(222, 184, 135);
        public static DotColor CadetBlue { get; } = new DotColor(95, 158, 160);
        public static DotColor Chartreuse { get; } = new DotColor(127, 255, 0);
        public static DotColor Chocolate { get; } = new DotColor(210, 105, 30);
        public static DotColor Coral { get; } = new DotColor(255, 127, 80);
        public static DotColor CornflowerBlue { get; } = new DotColor(100, 149, 237);
        public static DotColor Cornsilk { get; } = new DotColor(255, 248, 220);
        public static DotColor Crimson { get; } = new DotColor(220, 20, 60);
        public static DotColor Cyan { get; } = new DotColor(0, 255, 255);
        public static DotColor DarkBlue { get; } = new DotColor(0, 0, 139);
        public static DotColor DarkCyan { get; } = new DotColor(0, 139, 139);
        public static DotColor DarkGoldenrod { get; } = new DotColor(184, 134, 11);
        public static DotColor DarkGray { get; } = new DotColor(169, 169, 169);
        public static DotColor DarkGreen { get; } = new DotColor(0, 100, 0);
        public static DotColor DarkGrey { get; } = new DotColor(169, 169, 169);
        public static DotColor DarkKhaki { get; } = new DotColor(189, 183, 107);
        public static DotColor DarkMagenta { get; } = new DotColor(139, 0, 139);
        public static DotColor DarkOliveGreen { get; } = new DotColor(85, 107, 47);
        public static DotColor Darkorange { get; } = new DotColor(255, 140, 0);
        public static DotColor DarkOrchid { get; } = new DotColor(153, 50, 204);
        public static DotColor DarkRed { get; } = new DotColor(139, 0, 0);
        public static DotColor DarkSalmon { get; } = new DotColor(233, 150, 122);
        public static DotColor DarkSeaGreen { get; } = new DotColor(143, 188, 143);
        public static DotColor DarkSlateBlue { get; } = new DotColor(72, 61, 139);
        public static DotColor DarkSlateGray { get; } = new DotColor(47, 79, 79);
        public static DotColor DarkSlateGrey { get; } = new DotColor(47, 79, 79);
        public static DotColor DarkTurquoise { get; } = new DotColor(0, 206, 209);
        public static DotColor DarkViolet { get; } = new DotColor(148, 0, 211);
        public static DotColor DeepPink { get; } = new DotColor(255, 20, 147);
        public static DotColor DeepSkyBlue { get; } = new DotColor(0, 191, 255);
        public static DotColor DimGray { get; } = new DotColor(105, 105, 105);
        public static DotColor DimGrey { get; } = new DotColor(105, 105, 105);
        public static DotColor DodgerBlue { get; } = new DotColor(30, 144, 255);
        public static DotColor Firebrick { get; } = new DotColor(178, 34, 34);
        public static DotColor FloralWhite { get; } = new DotColor(255, 250, 240);
        public static DotColor ForestGreen { get; } = new DotColor(34, 139, 34);
        public static DotColor Fuchsia { get; } = new DotColor(255, 0, 255);
        public static DotColor Gainsboro { get; } = new DotColor(220, 220, 220);
        public static DotColor GhostWhite { get; } = new DotColor(248, 248, 255);
        public static DotColor Gold { get; } = new DotColor(255, 215, 0);
        public static DotColor Goldenrod { get; } = new DotColor(218, 165, 32);
        public static DotColor Gray { get; } = new DotColor(128, 128, 128);
        public static DotColor Green { get; } = new DotColor(0, 128, 0);
        public static DotColor GreenYellow { get; } = new DotColor(173, 255, 47);
        public static DotColor Grey { get; } = new DotColor(128, 128, 128);
        public static DotColor Honeydew { get; } = new DotColor(240, 255, 240);
        public static DotColor HotPink { get; } = new DotColor(255, 105, 180);
        public static DotColor IndianRed { get; } = new DotColor(205, 92, 92);
        public static DotColor Indigo { get; } = new DotColor(75, 0, 130);
        public static DotColor Ivory { get; } = new DotColor(255, 255, 240);
        public static DotColor Khaki { get; } = new DotColor(240, 230, 140);
        public static DotColor Lavender { get; } = new DotColor(230, 230, 250);
        public static DotColor LavenderBlush { get; } = new DotColor(255, 240, 245);
        public static DotColor LawnGreen { get; } = new DotColor(124, 252, 0);
        public static DotColor LemonChiffon { get; } = new DotColor(255, 250, 205);
        public static DotColor LightBlue { get; } = new DotColor(173, 216, 230);
        public static DotColor LightCoral { get; } = new DotColor(240, 128, 128);
        public static DotColor LightCyan { get; } = new DotColor(224, 255, 255);
        public static DotColor LightGoldenrodYellow { get; } = new DotColor(250, 250, 210);
        public static DotColor LightGray { get; } = new DotColor(211, 211, 211);
        public static DotColor LightGrey { get; } = new DotColor(211, 211, 211);
        public static DotColor LightGreen { get; } = new DotColor(144, 238, 144);
        public static DotColor LightPink { get; } = new DotColor(255, 182, 193);
        public static DotColor LightSalmon { get; } = new DotColor(255, 160, 122);
        public static DotColor LightSeaGreen { get; } = new DotColor(32, 178, 170);
        public static DotColor LightSkyBlue { get; } = new DotColor(135, 206, 250);
        public static DotColor LightSlateGray { get; } = new DotColor(119, 136, 153);
        public static DotColor LightSlateGrey { get; } = new DotColor(119, 136, 153);
        public static DotColor LightSteelBlue { get; } = new DotColor(176, 196, 222);
        public static DotColor LightYellow { get; } = new DotColor(255, 255, 224);
        public static DotColor Lime { get; } = new DotColor(0, 255, 0);
        public static DotColor LimeGreen { get; } = new DotColor(50, 205, 50);
        public static DotColor Linen { get; } = new DotColor(250, 240, 230);
        public static DotColor Magenta { get; } = new DotColor(255, 0, 255);
        public static DotColor Maroon { get; } = new DotColor(128, 0, 0);
        public static DotColor MediumAquamarine { get; } = new DotColor(102, 205, 170);
        public static DotColor MediumBlue { get; } = new DotColor(0, 0, 205);
        public static DotColor MediumOrchid { get; } = new DotColor(186, 85, 211);
        public static DotColor MediumPurple { get; } = new DotColor(147, 112, 219);
        public static DotColor MediumSeaGreen { get; } = new DotColor(60, 179, 113);
        public static DotColor MediumSlateBlue { get; } = new DotColor(123, 104, 238);
        public static DotColor MediumSpringGreen { get; } = new DotColor(0, 250, 154);
        public static DotColor MediumTurquoise { get; } = new DotColor(72, 209, 204);
        public static DotColor MediumVioletRed { get; } = new DotColor(199, 21, 133);
        public static DotColor MidnightBlue { get; } = new DotColor(25, 25, 112);
        public static DotColor MintCream { get; } = new DotColor(245, 255, 250);
        public static DotColor MistyRose { get; } = new DotColor(255, 228, 225);
        public static DotColor Moccasin { get; } = new DotColor(255, 228, 181);
        public static DotColor NavajoWhite { get; } = new DotColor(255, 222, 173);
        public static DotColor Navy { get; } = new DotColor(0, 0, 128);
        public static DotColor OldLace { get; } = new DotColor(253, 245, 230);
        public static DotColor Olive { get; } = new DotColor(128, 128, 0);
        public static DotColor OliveDrab { get; } = new DotColor(107, 142, 35);
        public static DotColor Orange { get; } = new DotColor(255, 165, 0);
        public static DotColor OrangeRed { get; } = new DotColor(255, 69, 0);
        public static DotColor Orchid { get; } = new DotColor(218, 112, 214);
        public static DotColor PaleGoldenrod { get; } = new DotColor(238, 232, 170);
        public static DotColor PaleGreen { get; } = new DotColor(152, 251, 152);
        public static DotColor PaleTurquoise { get; } = new DotColor(175, 238, 238);
        public static DotColor PaleVioletRed { get; } = new DotColor(219, 112, 147);
        public static DotColor PapayaWhip { get; } = new DotColor(255, 239, 213);
        public static DotColor PeachPuff { get; } = new DotColor(255, 218, 185);
        public static DotColor Peru { get; } = new DotColor(205, 133, 63);
        public static DotColor Pink { get; } = new DotColor(255, 192, 203);
        public static DotColor Plum { get; } = new DotColor(221, 160, 221);
        public static DotColor PowderBlue { get; } = new DotColor(176, 224, 230);
        public static DotColor Purple { get; } = new DotColor(128, 0, 128);
        public static DotColor Red { get; } = new DotColor(255, 0, 0);
        public static DotColor RosyBrown { get; } = new DotColor(188, 143, 143);
        public static DotColor RoyalBlue { get; } = new DotColor(65, 105, 225);
        public static DotColor SaddleBrown { get; } = new DotColor(139, 69, 19);
        public static DotColor Salmon { get; } = new DotColor(250, 128, 114);
        public static DotColor SandyBrown { get; } = new DotColor(244, 164, 96);
        public static DotColor SeaGreen { get; } = new DotColor(46, 139, 87);
        public static DotColor SeaShell { get; } = new DotColor(255, 245, 238);
        public static DotColor Sienna { get; } = new DotColor(160, 82, 45);
        public static DotColor Silver { get; } = new DotColor(192, 192, 192);
        public static DotColor SkyBlue { get; } = new DotColor(135, 206, 235);
        public static DotColor SlateBlue { get; } = new DotColor(106, 90, 205);
        public static DotColor SlateGray { get; } = new DotColor(112, 128, 144);
        public static DotColor SlateGrey { get; } = new DotColor(112, 128, 144);
        public static DotColor Snow { get; } = new DotColor(255, 250, 250);
        public static DotColor SpringGreen { get; } = new DotColor(0, 255, 127);
        public static DotColor SteelBlue { get; } = new DotColor(70, 130, 180);
        public static DotColor Tan { get; } = new DotColor(210, 180, 140);
        public static DotColor Teal { get; } = new DotColor(0, 128, 128);
        public static DotColor Thistle { get; } = new DotColor(216, 191, 216);
        public static DotColor Tomato { get; } = new DotColor(255, 99, 71);
        public static DotColor Turquoise { get; } = new DotColor(64, 224, 208);
        public static DotColor Violet { get; } = new DotColor(238, 130, 238);
        public static DotColor Wheat { get; } = new DotColor(245, 222, 179);
        public static DotColor White { get; } = new DotColor(255, 255, 255);
        public static DotColor WhiteSmoke { get; } = new DotColor(245, 245, 245);
        public static DotColor Yellow { get; } = new DotColor(255, 255, 0);
        public static DotColor YellowGreen { get; } = new DotColor(154, 205, 50);
    }
}