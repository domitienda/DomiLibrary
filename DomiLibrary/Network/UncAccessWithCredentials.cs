﻿using System;
using System.Runtime.InteropServices;

namespace DomiLibrary.Network
{
    public class UncAccessWithCredentials : IDisposable
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct UseInfo2
        {
            internal String ui2_local;
            internal String ui2_remote;
            internal String ui2_password;
            internal UInt32 ui2_status;
            internal UInt32 ui2_asg_type;
            internal UInt32 ui2_refcount;
            internal UInt32 ui2_usecount;
            internal String ui2_username;
            internal String ui2_domainname;
        }

        [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern UInt32 NetUseAdd(
            String uncServerName,
            UInt32 level,
            ref UseInfo2 buf,
            out UInt32 parmError);

        [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern UInt32 NetUseDel(
            String uncServerName,
            String useName,
            UInt32 forceCond);

        private bool _disposed;

        private string _sUncPath;
        private string _sUser;
        private string _sPassword;
        private string _sDomain;

        /// <summary>
        /// The last system error code returned from NetUseAdd or NetUseDel.  Success = 0
        /// </summary>
        public int LastError { get; private set; }

        public void Dispose()
        {
            if (!_disposed)
            {
                NetUseDelete();
            }
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Connects to a UNC path using the credentials supplied.
        /// </summary>
        /// <param name="uncPath">Fully qualified domain name UNC path</param>
        /// <param name="user">A user with sufficient rights to access the path.</param>
        /// <param name="domain">Domain of User.</param>
        /// <param name="password">Password of User</param>
        /// <returns>True if mapping succeeds.  Use LastError to get the system error code.</returns>
        public bool NetUseWithCredentials(string uncPath, string user, string domain, string password)
        {
            _sUncPath = uncPath;
            _sUser = user;
            _sPassword = password;
            _sDomain = domain;
            return NetUseWithCredentials();
        }

        private bool NetUseWithCredentials()
        {
            try
            {
                var useinfo = new UseInfo2
                                  {
                                      ui2_remote = _sUncPath,
                                      ui2_username = _sUser,
                                      ui2_domainname = _sDomain,
                                      ui2_password = _sPassword,
                                      ui2_asg_type = 0,
                                      ui2_usecount = 1
                                  };

                uint paramErrorIndex;
                var returncode = NetUseAdd(null, 2, ref useinfo, out paramErrorIndex);
                LastError = (int)returncode;
                return returncode == 0;
            }
            catch
            {
                LastError = Marshal.GetLastWin32Error();
                return false;
            }
        }

        /// <summary>
        /// Ends the connection to the remote resource 
        /// </summary>
        /// <returns>True if it succeeds.  Use LastError to get the system error code</returns>
        public bool NetUseDelete()
        {
            try
            {
                var returncode = NetUseDel(null, _sUncPath, 2);
                LastError = (int)returncode;
                return (returncode == 0);
            }
            catch
            {
                LastError = Marshal.GetLastWin32Error();
                return false;
            }
        }

        ~UncAccessWithCredentials()
        {
            Dispose();
        }

    }
}
