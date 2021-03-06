using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MediaBrowser.Model.IO
{
    /// <summary>
    /// Interface IFileSystem
    /// </summary>
    public interface IFileSystem
    {
        void AddShortcutHandler(IShortcutHandler handler);

        /// <summary>
        /// Determines whether the specified filename is shortcut.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns><c>true</c> if the specified filename is shortcut; otherwise, <c>false</c>.</returns>
        bool IsShortcut(string filename);

        /// <summary>
        /// Resolves the shortcut.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>System.String.</returns>
        string ResolveShortcut(string filename);

        /// <summary>
        /// Creates the shortcut.
        /// </summary>
        /// <param name="shortcutPath">The shortcut path.</param>
        /// <param name="target">The target.</param>
        void CreateShortcut(string shortcutPath, string target);

        string MakeAbsolutePath(string folderPath, string filePath);

        /// <summary>
        /// Returns a <see cref="FileSystemMetadata" /> object for the specified file or directory path.
        /// </summary>
        /// <param name="path">A path to a file or directory.</param>
        /// <returns>A <see cref="FileSystemMetadata" /> object.</returns>
        /// <remarks>If the specified path points to a directory, the returned <see cref="FileSystemMetadata" /> object's
        /// <see cref="FileSystemMetadata.IsDirectory" /> property will be set to true and all other properties will reflect the properties of the directory.</remarks>
        FileSystemMetadata GetFileSystemInfo(string path);

        /// <summary>
        /// Returns a <see cref="FileSystemMetadata" /> object for the specified file path.
        /// </summary>
        /// <param name="path">A path to a file.</param>
        /// <returns>A <see cref="FileSystemMetadata" /> object.</returns>
        /// <remarks><para>If the specified path points to a directory, the returned <see cref="FileSystemMetadata" /> object's
        /// <see cref="FileSystemMetadata.IsDirectory" /> property and the <see cref="FileSystemMetadata.Exists" /> property will both be set to false.</para>
        /// <para>For automatic handling of files <b>and</b> directories, use <see cref="M:IFileSystem.GetFileSystemInfo(System.String)" />.</para></remarks>
        FileSystemMetadata GetFileInfo(string path);

        /// <summary>
        /// Returns a <see cref="FileSystemMetadata" /> object for the specified directory path.
        /// </summary>
        /// <param name="path">A path to a directory.</param>
        /// <returns>A <see cref="FileSystemMetadata" /> object.</returns>
        /// <remarks><para>If the specified path points to a file, the returned <see cref="FileSystemMetadata" /> object's
        /// <see cref="FileSystemMetadata.IsDirectory" /> property will be set to true and the <see cref="FileSystemMetadata.Exists" /> property will be set to false.</para>
        /// <para>For automatic handling of files <b>and</b> directories, use <see cref="M:IFileSystem.GetFileSystemInfo(System.String)" />.</para></remarks>
        FileSystemMetadata GetDirectoryInfo(string path);

        /// <summary>
        /// Gets the valid filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>System.String.</returns>
        string GetValidFilename(string filename);

        /// <summary>
        /// Gets the creation time UTC.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>DateTime.</returns>
        DateTime GetCreationTimeUtc(FileSystemMetadata info);

        /// <summary>
        /// Gets the creation time UTC.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>DateTime.</returns>
        DateTime GetCreationTimeUtc(string path);

        /// <summary>
        /// Gets the last write time UTC.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>DateTime.</returns>
        DateTime GetLastWriteTimeUtc(FileSystemMetadata info);

        /// <summary>
        /// Gets the last write time UTC.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>DateTime.</returns>
        DateTime GetLastWriteTimeUtc(string path);

        /// <summary>
        /// Gets the file stream.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="access">The access.</param>
        /// <param name="share">The share.</param>
        /// <param name="isAsync">if set to <c>true</c> [is asynchronous].</param>
        /// <returns>FileStream.</returns>
        Stream GetFileStream(string path, FileOpenMode mode, FileAccessMode access, FileShareMode share, bool isAsync = false);

        Stream GetFileStream(string path, FileOpenMode mode, FileAccessMode access, FileShareMode share,
            FileOpenOptions fileOpenOptions);

        string DefaultDirectory { get; }

        /// <summary>
        /// Swaps the files.
        /// </summary>
        /// <param name="file1">The file1.</param>
        /// <param name="file2">The file2.</param>
        void SwapFiles(string file1, string file2);

        bool AreEqual(string path1, string path2);

        /// <summary>
        /// Determines whether [contains sub path] [the specified parent path].
        /// </summary>
        /// <param name="parentPath">The parent path.</param>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [contains sub path] [the specified parent path]; otherwise, <c>false</c>.</returns>
        bool ContainsSubPath(string parentPath, string path);

        /// <summary>
        /// Determines whether [is root path] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is root path] [the specified path]; otherwise, <c>false</c>.</returns>
        bool IsRootPath(string path);

        /// <summary>
        /// Normalizes the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        string NormalizePath(string path);

        /// <summary>
        /// Gets the file name without extension.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>System.String.</returns>
        string GetFileNameWithoutExtension(FileSystemMetadata info);

        /// <summary>
        /// Determines whether [is path file] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if [is path file] [the specified path]; otherwise, <c>false</c>.</returns>
        bool IsPathFile(string path);

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        void DeleteFile(string path);

        /// <summary>
        /// Gets the directories.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns>IEnumerable&lt;DirectoryInfo&gt;.</returns>
        IEnumerable<FileSystemMetadata> GetDirectories(string path, bool recursive = false);

        /// <summary>
        /// Gets the files.
        /// </summary>
        IEnumerable<FileSystemMetadata> GetFiles(string path, bool recursive = false);

        IEnumerable<FileSystemMetadata> GetFiles(string path, string[] extensions, bool enableCaseSensitiveExtensions, bool recursive);

        /// <summary>
        /// Gets the file system entries.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns>IEnumerable&lt;FileSystemMetadata&gt;.</returns>
        IEnumerable<FileSystemMetadata> GetFileSystemEntries(string path, bool recursive = false);

        /// <summary>
        /// Gets the directory paths.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> GetDirectoryPaths(string path, bool recursive = false);

        /// <summary>
        /// Gets the file paths.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> GetFilePaths(string path, bool recursive = false);

        IEnumerable<string> GetFilePaths(string path, string[] extensions, bool enableCaseSensitiveExtensions, bool recursive);

        /// <summary>
        /// Gets the file system entry paths.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> GetFileSystemEntryPaths(string path, bool recursive = false);

        void SetHidden(string path, bool isHidden);
        void SetReadOnly(string path, bool readOnly);
        void SetAttributes(string path, bool isHidden, bool readOnly);
        List<FileSystemMetadata> GetDrives();
        void SetExecutable(string path);
    }

    //TODO Investigate if can be replaced by the one from System.IO ?
    public enum FileOpenMode
    {
        //
        // Summary:
        //     Specifies that the operating system should create a new file. This requires System.Security.Permissions.FileIOPermissionAccess.Write
        //     permission. If the file already exists, an System.IO.IOException exception is
        //     thrown.
        CreateNew = 1,
        //
        // Summary:
        //     Specifies that the operating system should create a new file. If the file already
        //     exists, it will be overwritten. This requires System.Security.Permissions.FileIOPermissionAccess.Write
        //     permission. FileMode.Create is equivalent to requesting that if the file does
        //     not exist, use System.IO.FileMode.CreateNew; otherwise, use System.IO.FileMode.Truncate.
        //     If the file already exists but is a hidden file, an System.UnauthorizedAccessException
        //     exception is thrown.
        Create = 2,
        //
        // Summary:
        //     Specifies that the operating system should open an existing file. The ability
        //     to open the file is dependent on the value specified by the System.IO.FileAccess
        //     enumeration. A System.IO.FileNotFoundException exception is thrown if the file
        //     does not exist.
        Open = 3,
        //
        // Summary:
        //     Specifies that the operating system should open a file if it exists; otherwise,
        //     a new file should be created. If the file is opened with FileAccess.Read, System.Security.Permissions.FileIOPermissionAccess.Read
        //     permission is required. If the file access is FileAccess.Write, System.Security.Permissions.FileIOPermissionAccess.Write
        //     permission is required. If the file is opened with FileAccess.ReadWrite, both
        //     System.Security.Permissions.FileIOPermissionAccess.Read and System.Security.Permissions.FileIOPermissionAccess.Write
        //     permissions are required.
        OpenOrCreate = 4
    }

    public enum FileAccessMode
    {
        //
        // Summary:
        //     Read access to the file. Data can be read from the file. Combine with Write for
        //     read/write access.
        Read = 1,
        //
        // Summary:
        //     Write access to the file. Data can be written to the file. Combine with Read
        //     for read/write access.
        Write = 2
    }

    public enum FileShareMode
    {
        //
        // Summary:
        //     Declines sharing of the current file. Any request to open the file (by this process
        //     or another process) will fail until the file is closed.
        None = 0,
        //
        // Summary:
        //     Allows subsequent opening of the file for reading. If this flag is not specified,
        //     any request to open the file for reading (by this process or another process)
        //     will fail until the file is closed. However, even if this flag is specified,
        //     additional permissions might still be needed to access the file.
        Read = 1,
        //
        // Summary:
        //     Allows subsequent opening of the file for writing. If this flag is not specified,
        //     any request to open the file for writing (by this process or another process)
        //     will fail until the file is closed. However, even if this flag is specified,
        //     additional permissions might still be needed to access the file.
        Write = 2,
        //
        // Summary:
        //     Allows subsequent opening of the file for reading or writing. If this flag is
        //     not specified, any request to open the file for reading or writing (by this process
        //     or another process) will fail until the file is closed. However, even if this
        //     flag is specified, additional permissions might still be needed to access the
        //     file.
        ReadWrite = 3
    }

    //
    // Summary:
    //     Represents advanced options for creating a System.IO.FileStream object.
    [Flags]
    public enum FileOpenOptions
    {
        //
        // Summary:
        //     Indicates that the system should write through any intermediate cache and go
        //     directly to disk.
        WriteThrough = int.MinValue,
        //
        // Summary:
        //     Indicates that no additional options should be used when creating a System.IO.FileStream
        //     object.
        None = 0,
        //
        // Summary:
        //     Indicates that a file is encrypted and can be decrypted only by using the same
        //     user account used for encryption.
        Encrypted = 16384,
        //
        // Summary:
        //     Indicates that a file is automatically deleted when it is no longer in use.
        DeleteOnClose = 67108864,
        //
        // Summary:
        //     Indicates that the file is to be accessed sequentially from beginning to end.
        //     The system can use this as a hint to optimize file caching. If an application
        //     moves the file pointer for random access, optimum caching may not occur; however,
        //     correct operation is still guaranteed.
        SequentialScan = 134217728,
        //
        // Summary:
        //     Indicates that the file is accessed randomly. The system can use this as a hint
        //     to optimize file caching.
        RandomAccess = 268435456,
        //
        // Summary:
        //     Indicates that a file can be used for asynchronous reading and writing.
        Asynchronous = 1073741824
    }
}
