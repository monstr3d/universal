using System;
using System.Buffers;
using System.Collections.Generic;

namespace KeyboardHMI
{

    public static class MemoryHelpers
    {

        public sealed class SequenceSegment<T> : ReadOnlySequenceSegment<T>
        {
            public SequenceSegment(ReadOnlyMemory<T> memory, long runningIndex)
            {
                this.Memory = memory;
                this.RunningIndex = runningIndex;
            }

            public void SetNext(SequenceSegment<T> next)
            {
                this.Next = next;
            }
        }


        public static ReadOnlySequence<T> CreateSequence<T>(T[] data)
        {
            return new ReadOnlySequence<T>(data);
        }
        public static ReadOnlySequence<T> CreateSequenceInSegments<T>(T[] data, int segmentLength)
        {
            ReadOnlySequence<T> retval = default;
            int position = 0;
            int remaining = data.Length - position;
            int length = segmentLength < remaining ? segmentLength : remaining;
            if (length > 0)
            {
                var head = new SequenceSegment<T>(new ReadOnlyMemory<T>(data, 0, length), position);
                var current = head;
                position += length;
                remaining = data.Length - position;
                while (remaining > 0)
                {
                    length = segmentLength < remaining ? segmentLength : remaining;
                    SequenceSegment<T> newSegment = new SequenceSegment<T>(new ReadOnlyMemory<T>(data, position, length), position);
                    current.SetNext(newSegment);
                    current = newSegment;
                    position += length;
                    remaining = data.Length - position;
                }
                retval = new ReadOnlySequence<T>(head, 0, current, current.Memory.Length);
            }

            return retval;
        }

        public static ReadOnlySequence<T> CreateSequenceFromBlocks<T>(IEnumerable<T[]> data)
        {
            ReadOnlySequence<T> retval = default;
            var enumerator = data.GetEnumerator();
            if (enumerator.MoveNext())
            {

                var block = enumerator.Current;
                var head = new SequenceSegment<T>(new ReadOnlyMemory<T>(block), 0);
                long position = block.Length;
                var current = head;
                while (enumerator.MoveNext())
                {
                    block = enumerator.Current;
                    SequenceSegment<T> newSegment = new SequenceSegment<T>(new ReadOnlyMemory<T>(block), position);
                    current.SetNext(newSegment);
                    current = newSegment;
                    position += block.Length;
                }
                retval = new ReadOnlySequence<T>(head, 0, current, current.Memory.Length);
            }
            return retval;
        }
    }
}
