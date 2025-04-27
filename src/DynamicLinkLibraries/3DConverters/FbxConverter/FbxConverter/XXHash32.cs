using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FbxConverter
{
    public class XXHash32
    {
        private static readonly uint _seed = (uint)DateTime.UtcNow.Ticks;

        private const uint Prime1 = 2654435761U;
        private const uint Prime2 = 2246822519U;
        private const uint Prime3 = 3266489917U;
        private const uint Prime4 = 668265263U;
        private const uint Prime5 = 374761393U;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public  int ComputeHash(byte[] data)
        {
            var byteLength = data.Length;
            Debug.Assert(data.Length >= 0);
            
            if (data.Length == 0) { return 0; }
            if (byteLength < 16)
            {
                var acc = _seed + Prime5 + (uint)byteLength;
                return (int)ComputeHashShort(data, byteLength, acc);
            }
            else
            {
                return (int)ComputeHashFull(data);
            }
        }

        uint ComputeHashShort(byte[] data, int byteLength, uint acc)
        {
            Debug.Assert(byteLength < 16 && byteLength >= 0);

            var laneCount = Math.DivRem(byteLength, 4, out int mod4);
            if (laneCount == 1)
            {
                acc = AccumRemainingLane(acc, Get(data, 0));
            }
            else if (laneCount == 2)
            {
                acc = AccumRemainingLane(acc, Get(data, 0));
                acc = AccumRemainingLane(acc, Get(data, 1));
            }
            else if (laneCount == 3)
            {
                acc = AccumRemainingLane(acc, Get(data, 0));
                acc = AccumRemainingLane(acc, Get(data, 1));
                acc = AccumRemainingLane(acc, Get(data, 2));
            }
            var bytes = new byte[byteLength];
            Array.Copy(data, data.Length + 4 * laneCount, bytes, 0, bytes.Length);
            if (mod4 == 1)
            {
                acc = AccumByte(acc, bytes[0]);
            }
            else if (mod4 == 2)
            {
                acc = AccumByte(acc, bytes[0]);
                acc = AccumByte(acc, bytes[1]);
            }
            else if (mod4 == 3)
            {
                acc = AccumByte(acc, bytes[0]);
                acc = AccumByte(acc, bytes[1]);
                acc = AccumByte(acc, bytes[2]);
            }
            return MixFinal(acc);
        }
        uint Get(byte[] data, int index)
        {
            var b = new byte[4];
            Array.Copy(data, 4 * index, b, 0, 4);
            return BitConverter.ToUInt32(b, 0);
        }

        private  uint ComputeHashFull(byte[] data)
        {
            var byteLength = data.Length;
            var blockCount = Math.DivRem(byteLength, 16, out int mod16);
            Initialize(out uint acc1, out uint acc2, out uint acc3, out uint acc4);
            for (int i = 0; i < blockCount; i++)
            {
                uint lane1 = Get(data, 0);
                uint lane2 = Get(data, 1);
                uint lane3 = Get(data, 2);
                uint lane4 = Get(data, 3);
                /*  uint lane1 = *(uint*)(data + 16 * i);
                  uint lane2 = *(uint*)(data + 16 * i + 4);
                  uint lane3 = *(uint*)(data + 16 * i + 8);
                  uint lane4 = *(uint*)(data + 16 * i + 12);*/
                acc1 = AccumBlockLane(acc1, lane1);
                acc2 = AccumBlockLane(acc2, lane2);
                acc3 = AccumBlockLane(acc3, lane3);
                acc4 = AccumBlockLane(acc4, lane4);
            }
            uint acc = MixState(acc1, acc2, acc3, acc4) + (uint)byteLength;
            throw new ErrorHandler.OwnNotImplemented("FBX Conerter");
            return 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Initialize(out uint v1, out uint v2, out uint v3, out uint v4)
        {
            v1 = _seed + Prime1 + Prime2;
            v2 = _seed + Prime2;
            v3 = _seed;
            v4 = _seed - Prime1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint AccumBlockLane(uint hash, uint lane)
        {
            return BitOperationHelper.RotateLeft(hash + lane * Prime2, 13) * Prime1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint AccumRemainingLane(uint hash, uint lane)
        {
            return BitOperationHelper.RotateLeft(hash + lane * Prime3, 17) * Prime4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint AccumByte(uint hash, byte b)
        {
            return BitOperationHelper.RotateLeft(hash + (uint)b * Prime5, 11) * Prime1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint MixState(uint v1, uint v2, uint v3, uint v4)
        {
            return BitOperationHelper.RotateLeft(v1, 1) + BitOperationHelper.RotateLeft(v2, 7) + BitOperationHelper.RotateLeft(v3, 12) + BitOperationHelper.RotateLeft(v4, 18);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint MixFinal(uint hash)
        {
            hash ^= hash >> 15;
            hash *= Prime2;
            hash ^= hash >> 13;
            hash *= Prime3;
            hash ^= hash >> 16;
            return hash;
        }
    }
}

