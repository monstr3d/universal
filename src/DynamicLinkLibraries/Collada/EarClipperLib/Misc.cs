using PeterO.Numbers;

/*
Copyright (c) 2012-2021 NMO13

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/


namespace EarClipperLib
{
    class Misc
    {
        public static int GetOrientation(Vector3m v0, Vector3m v1, Vector3m v2, Vector3m normal)
        {
            var res = (v0 - v1).Cross(v2 - v1);
            if (res.LengthSquared().IsZero)
                return 0;
            if (res.X.Sign != normal.X.Sign || res.Y.Sign != normal.Y.Sign || res.Z.Sign != normal.Z.Sign)
                return 1;
            return -1;
        }

        // Is testPoint between a and b in ccw order?
        // > 0 if strictly yes
        // < 0 if strictly no
        // = 0 if testPoint lies either on a or on b
        public static int IsBetween(Vector3m Origin, Vector3m a, Vector3m b, Vector3m testPoint, Vector3m normal)
        {
            var psca = GetOrientation(Origin, a, testPoint, normal);
            var pscb = GetOrientation(Origin, b, testPoint, normal);

            // where does b in relation to a lie? Left, right or collinear?
            var psb = GetOrientation(Origin, a, b, normal);
            if (psb > 0) // left
            {
                // if left then testPoint lies between a and b iff testPoint left of a AND testPoint right of b
                if (psca > 0 && pscb < 0)
                    return 1;
                if (psca == 0)
                {
                    var t = a - Origin;
                    var t2 = testPoint - Origin;
                    if (t.X.Sign != t2.X.Sign || t.Y.Sign != t2.Y.Sign)
                        return -1;
                    return 0;
                }
                else if (pscb == 0)
                {
                    var t = b - Origin;
                    var t2 = testPoint - Origin;
                    if (t.X.Sign != t2.X.Sign || t.Y.Sign != t2.Y.Sign)
                        return -1;
                    return 0;
                }
            }
            else if (psb < 0) // right
            {
                // if right then testPoint lies between a and b iff testPoint left of a OR testPoint right of b
                if (psca > 0 || pscb < 0)
                    return 1;
                if (psca == 0)
                {
                    var t = a - Origin;
                    var t2 = testPoint - Origin;
                    if (t.X.Sign != t2.X.Sign || t.Y.Sign != t2.Y.Sign)
                        return 1;
                    return 0;
                }
                else if (pscb == 0)
                {
                    var t = b - Origin;
                    var t2 = testPoint - Origin;
                    if (t.X.Sign != t2.X.Sign || t.Y.Sign != t2.Y.Sign)
                        return 1;
                    return 0;
                }
            }
            else if (psb == 0)
            {
                if (psca > 0)
                    return 1;
                else if (psca < 0)
                    return -1;
                else
                    return 0;
            }

            return -1;
        }

        public static bool PointInOrOnTriangle(Vector3m prevPoint, Vector3m curPoint, Vector3m nextPoint,
            Vector3m nonConvexPoint, Vector3m normal)
        {
            var res0 = Misc.GetOrientation(prevPoint, nonConvexPoint, curPoint, normal);
            var res1 = Misc.GetOrientation(curPoint, nonConvexPoint, nextPoint, normal);
            var res2 = Misc.GetOrientation(nextPoint, nonConvexPoint, prevPoint, normal);
            return res0 != 1 && res1 != 1 && res2 != 1;
        }

        public static ERational PointLineDistance(Vector3m p1, Vector3m p2, Vector3m p3)
        {
            return (p2 - p1).Cross(p3 - p1).LengthSquared();
        }
    }
}