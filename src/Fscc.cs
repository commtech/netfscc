using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Threading;
using System.IO.Ports;
using System.Reflection;

namespace Fscc
{
    public enum TransmitModifiers { XF = 0, XREP = 1, TXT = 2, TXEXT = 4 };

    public class Port
    {
#if DEBUG
        public const string DLL_PATH = "cfsccd.dll";
#else
        public const string DLL_PATH = "cfscc.dll";
#endif

        IntPtr _handle;
        uint _port_num;
        Registers _registers;
        MemoryCap _memcap;

        public override string ToString()
        {
            return String.Format("FSCC{0}", _port_num);
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_connect(uint port_num, bool overlapped, out IntPtr h);

        public Port(uint port_num)
        {
            int e = fscc_connect(port_num, true, out this._handle);

            if (e >= 1)
                throw new Exception(e.ToString());

            this._port_num = port_num;
            this._registers = new Registers(this._handle);
            this._memcap = new MemoryCap(this._handle);
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_disconnect(IntPtr h);

        ~Port()
        {
            fscc_disconnect(this._handle);
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_set_tx_modifiers(IntPtr h, uint modifiers);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_get_tx_modifiers(IntPtr h, out uint modifiers);

        public TransmitModifiers TxModifiers
        {
            set
            {
                int e = fscc_set_tx_modifiers(this._handle, (uint)value);

                if (e >= 1)
                    throw new Exception(e.ToString());
            }

            get
            {
                uint modifiers;

                int e = fscc_get_tx_modifiers(this._handle, out modifiers);

                if (e >= 1)
                    throw new Exception(e.ToString());

                return (TransmitModifiers)modifiers;
            }
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_enable_append_status(IntPtr h);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_disable_append_status(IntPtr h);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_get_append_status(IntPtr h, out bool status);

        public bool AppendStatus
        {
            set
            {
                int e = 0;

                if (value == true)
                    e = fscc_enable_append_status(this._handle);
                else
                    e = fscc_disable_append_status(this._handle);

                if (e >= 1)
                    throw new Exception(e.ToString());
            }

            get
            {
                bool status;

                int e = fscc_get_append_status(this._handle, out status);

                if (e >= 1)
                    throw new Exception(e.ToString());

                return status;
            }
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_enable_append_timestamp(IntPtr h);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_disable_append_timestamp(IntPtr h);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_get_append_timestamp(IntPtr h, out bool timestamp);

        public bool AppendTimestamp
        {
            set
            {
                int e = 0;

                if (value == true)
                    e = fscc_enable_append_timestamp(this._handle);
                else
                    e = fscc_disable_append_timestamp(this._handle);

                if (e >= 1)
                    throw new Exception(e.ToString());
            }

            get
            {
                bool timestamp;

                int e = fscc_get_append_timestamp(this._handle, out timestamp);

                if (e >= 1)
                    throw new Exception(e.ToString());

                return timestamp;
            }
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_enable_ignore_timeout(IntPtr h);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_disable_ignore_timeout(IntPtr h);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_get_ignore_timeout(IntPtr h, out bool status);

        public bool IgnoreTimeout
        {
            set
            {
                int e = 0;

                if (value == true)
                    e = fscc_enable_ignore_timeout(this._handle);
                else
                    e = fscc_disable_ignore_timeout(this._handle);

                if (e >= 1)
                    throw new Exception(e.ToString());
            }

            get
            {
                bool status;

                int e = fscc_get_ignore_timeout(this._handle, out status);

                if (e >= 1)
                    throw new Exception(e.ToString());

                return status;
            }
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_enable_rx_multiple(IntPtr h);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_disable_rx_multiple(IntPtr h);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_get_rx_multiple(IntPtr h, out bool status);

        public bool RxMultiple
        {
            set
            {
                int e = 0;

                if (value == true)
                    e = fscc_enable_rx_multiple(this._handle);
                else
                    e = fscc_disable_rx_multiple(this._handle);

                if (e >= 1)
                    throw new Exception(e.ToString());
            }

            get
            {
                bool status;

                int e = fscc_get_rx_multiple(this._handle, out status);

                if (e >= 1)
                    throw new Exception(e.ToString());

                return status;
            }
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_purge(IntPtr h, bool tx, bool rx);

        public void Purge(bool tx, bool rx)
        {
            fscc_purge(this._handle, tx, rx);
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_set_clock_frequency(IntPtr h, uint frequency);

        public uint ClockFrequency
        {
            set
            {
                int e = 0;

                e = fscc_set_clock_frequency(this._handle, value);

                if (e >= 1)
                    throw new Exception(e.ToString());
            }
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_write(IntPtr h, byte[] buf, uint size, out uint bytes_written, out NativeOverlapped overlapped);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_write(IntPtr h, byte[] buf, uint size, out uint bytes_written, IntPtr overlapped);

        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool GetOverlappedResult(
            IntPtr hDevice,
            out NativeOverlapped lpOverlapped,
            out uint lpNumberOfBytesTransferred,
            bool bWait
        );

        public int Write(byte[] buf, uint size, out NativeOverlapped o)
        {
            uint bytes_written;

            int e = fscc_write(this._handle, buf, size, out bytes_written, out o);

            if (e >= 1 && e != 997)
                throw new Exception(e.ToString());

            return e;
        }

        public uint Write(byte[] buf, uint size)
        {
            NativeOverlapped o = new NativeOverlapped();
            uint bytes_written = 0;

            Write(buf, size, out o);

            GetOverlappedResult(this._handle, out o, out bytes_written, true);

            return bytes_written;
        }

        public uint Write(string s)
        {
            return Write(Encoding.ASCII.GetBytes(s), (uint)s.Length);
        }

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_read(IntPtr h, byte[] buf, uint size, out uint bytes_read, out NativeOverlapped overlapped);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_read(IntPtr h, byte[] buf, uint size, out uint bytes_read, IntPtr overlapped);

        [DllImport(DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_read_with_timeout(IntPtr h, byte[] buf, uint size, out uint bytes_read, uint timeout);

        public int Read(byte[] buf, uint size, out NativeOverlapped o)
        {
            uint bytes_read;

            int e = fscc_read(this._handle, buf, size, out bytes_read, out o);

            if (e >= 1 && e != 997)
                throw new Exception(e.ToString());

            return e;
        }

        public uint Read(byte[] buf, uint size)
        {
            NativeOverlapped o = new NativeOverlapped();
            uint bytes_read = 0;

            Read(buf, size, out o);

            GetOverlappedResult(this._handle, out o, out bytes_read, true);

            return bytes_read;
        }

        public uint Read(byte[] buf, uint size, uint timeout)
        {
            uint bytes_read;

            int e = fscc_read_with_timeout(this._handle, buf, size, out bytes_read, timeout);

            if (e >= 1)
                throw new Exception(e.ToString());

            return bytes_read;
        }

        public string Read(uint count)
        {
            System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
            byte[] input_bytes = new byte[count];
            uint bytes_read = 0;

            bytes_read = Read(input_bytes, (uint)input_bytes.Length);

            return encoder.GetString(input_bytes, 0, (int)bytes_read);
        }

        public string Read(uint count, uint timeout)
        {
            System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
            byte[] input_bytes = new byte[count];
            uint bytes_read = 0;

            bytes_read = Read(input_bytes, (uint)input_bytes.Length, timeout);

            return encoder.GetString(input_bytes, 0, (int)bytes_read);
        }

        public string Firmware
        {
            get
            {
                uint vstr = this.Registers.VSTR;

                byte PREV = (byte)((vstr & 0x0000FF00) >> 8);
                byte FREV = (byte)((vstr & 0x000000FF));

                return String.Format("{0:X}.{1:X2}", PREV, FREV);
            }
        }

        public Registers Registers
        {
            get
            {
                return this._registers;
            }
        }

        public MemoryCap MemoryCap
        {
            get
            {
                return this._memcap;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct _Registers
    {
        /* BAR 0 */
        private Int64 __reserved11;
        private Int64 __reserved12;

        public Int64 FIFOT;

        private Int64 __reserved21;
        private Int64 __reserved22;

        public Int64 CMDR;
        public Int64 STAR; /* Read-only */
        public Int64 CCR0;
        public Int64 CCR1;
        public Int64 CCR2;
        public Int64 BGR;
        public Int64 SSR;
        public Int64 SMR;
        public Int64 TSR;
        public Int64 TMR;
        public Int64 RAR;
        public Int64 RAMR;
        public Int64 PPR;
        public Int64 TCR;
        public Int64 VSTR;

        private Int64 __reserved41;

        public Int64 IMR;
        public Int64 DPLLR;

        /* BAR 2 */
        public Int64 FCR;

        public _Registers(bool init)
        {
            /* BAR 0 */
            __reserved11 = -1;
            __reserved12 = -1;

            FIFOT = -1;

            __reserved21 = -1;
            __reserved22 = -1;

            CMDR = -1;
            STAR = -1; /* Read-only */
            CCR0 = -1;
            CCR1 = -1;
            CCR2 = -1;
            BGR = -1;
            SSR = -1;
            SMR = -1;
            TSR = -1;
            TMR = -1;
            RAR = -1;
            RAMR = -1;
            PPR = -1;
            TCR = -1;
            VSTR = -1;

            __reserved41 = -1;

            IMR = -1;
            DPLLR = -1;

            /* BAR 2 */
            FCR = -1;
        }

    };

    public class Registers {
        IntPtr _handle;
        const int FSCC_UPDATE_VALUE = -2;

        public Registers(IntPtr h)
        {
            this._handle = h;
        }

        [DllImport(Port.DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_set_registers(IntPtr h, IntPtr registers);

        [DllImport(Port.DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_get_registers(IntPtr h, IntPtr registers);

        private _Registers GetRegisters(_Registers r)
        {
            IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(r));
            Marshal.StructureToPtr(r, buffer, false);

            int e = fscc_get_registers(this._handle, buffer);

            r = (_Registers)Marshal.PtrToStructure(buffer, typeof(_Registers));
            Marshal.FreeHGlobal(buffer);

            if (e >= 1)
                throw new Exception(e.ToString());

            return r;
        }

        private void SetRegisters(_Registers r)
        {
            IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(r));
            Marshal.StructureToPtr(r, buffer, false);

            int e = fscc_set_registers(this._handle, buffer);

            Marshal.FreeHGlobal(buffer);

            if (e >= 1)
                throw new Exception(e.ToString());
        }

        public UInt32 FIFOT
        {
            set
            {
                _Registers r = new _Registers(true);

                r.FIFOT = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.FIFOT = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).FIFOT;
            }
        }

        public UInt32 CMDR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.CMDR = value;

                SetRegisters(r);
            }
        }

        public UInt32 STAR
        {
            get
            {
                _Registers r = new _Registers(true);

                r.STAR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).STAR;
            }
        }

        public UInt32 CCR0
        {
            set
            {
                _Registers r = new _Registers(true);

                r.CCR0 = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.CCR0 = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).CCR0;
            }
        }

        public UInt32 CCR1
        {
            set
            {
                _Registers r = new _Registers(true);

                r.CCR1 = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.CCR1 = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).CCR1;
            }
        }

        public UInt32 CCR2
        {
            set
            {
                _Registers r = new _Registers(true);

                r.CCR2 = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.CCR2 = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).CCR2;
            }
        }

        public UInt32 BGR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.BGR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.BGR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).BGR;
            }
        }

        public UInt32 SSR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.SSR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.SSR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).SSR;
            }
        }

        public UInt32 SMR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.SMR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.SMR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).SMR;
            }
        }

        public UInt32 TSR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.TSR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.TSR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).TSR;
            }
        }

        public UInt32 TMR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.TMR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.TMR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).TMR;
            }
        }

        public UInt32 RAR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.RAR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.RAR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).RAR;
            }
        }

        public UInt32 RAMR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.RAMR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.RAMR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).RAMR;
            }
        }

        public UInt32 PPR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.PPR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.PPR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).PPR;
            }
        }

        public UInt32 TCR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.TCR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.TCR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).TCR;
            }
        }

        public UInt32 VSTR
        {
            get
            {
                _Registers r = new _Registers(true);

                r.VSTR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).VSTR;
            }
        }

        public UInt32 IMR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.IMR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.IMR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).IMR;
            }
        }

        public UInt32 DPLLR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.DPLLR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.DPLLR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).DPLLR;
            }
        }

        public UInt32 FCR
        {
            set
            {
                _Registers r = new _Registers(true);

                r.FCR = value;

                SetRegisters(r);
            }

            get
            {
                _Registers r = new _Registers(true);

                r.FCR = FSCC_UPDATE_VALUE;

                return (UInt32)GetRegisters(r).FCR;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct _MemoryCap
    {
        public int input;
        public int output;

        public _MemoryCap(bool init)
        {
            input = -1;
            output = -1;
        }
    };

    public class MemoryCap {
        IntPtr _handle;

        public MemoryCap(IntPtr h)
        {
            this._handle = h;
        }

        [DllImport(Port.DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_set_memory_cap(IntPtr h, IntPtr memcap);

        [DllImport(Port.DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int fscc_get_memory_cap(IntPtr h, IntPtr memcap);

        private _MemoryCap GetMemoryCap(_MemoryCap m)
        {
            IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(m));
            Marshal.StructureToPtr(m, buffer, false);

            int e = fscc_get_memory_cap(this._handle, buffer);

            m = (_MemoryCap)Marshal.PtrToStructure(buffer, typeof(_MemoryCap));
            Marshal.FreeHGlobal(buffer);

            if (e >= 1)
                throw new Exception(e.ToString());

            return m;
        }

        private void SetMemoryCap(_MemoryCap m)
        {
            IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(m));
            Marshal.StructureToPtr(m, buffer, false);

            int e = fscc_set_memory_cap(this._handle, buffer);

            Marshal.FreeHGlobal(buffer);

            if (e >= 1)
                throw new Exception(e.ToString());
        }

        public uint Input
        {
            set
            {
                _MemoryCap m = new _MemoryCap(true);

                m.input = (int)value;

                SetMemoryCap(m);
            }

            get
            {
                _MemoryCap m = new _MemoryCap(true);

                return (uint)GetMemoryCap(m).input;
            }
        }

        public uint Output
        {
            set
            {
                _MemoryCap m = new _MemoryCap(true);

                m.output = (int)value;

                SetMemoryCap(m);
            }

            get
            {
                _MemoryCap m = new _MemoryCap(true);

                return (uint)GetMemoryCap(m).output;
            }
        }
    }
}