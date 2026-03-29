using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ArcX_Studio
{
    class ArchiveWorker
    {
        public void ExtractArchive(string arcPath, string workingPath, LoadingForm lf = null)
        {
            try
            {
                List<ArcEntry> list = new List<ArcEntry>();
                byte[] array = FileUtils.smethod_0(arcPath);
                MemoryStream memoryStream = null;
                if (array != null) // Check if the was successfully read
                {
                    memoryStream = new MemoryStream(array); // Loads the byte array to the memoryStream
                    int num = ArrSupport.GetInt32(memoryStream); // Gets the first 4 bytes as an integer
                    if (num < 0 || num > 100000)
                        throw new Exception("Invalid file size");

                    for (int i = 0; i < num; i++) // Loop for each file in the archive
                    {
                        string name = method_0(memoryStream); // Gets the name of the archive
                        int pos = ArrSupport.GetInt32(memoryStream);
                        int size = ArrSupport.GetInt32(memoryStream);
                        if (size == 0)
                            continue;
                        ArcEntry item = new ArcEntry(name, size, pos);
                        list.Add(item); // Add enteries to the list
                    }
                }
                method_1(workingPath, list, memoryStream, lf);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to extract ARC: {ex.Message}", ex);
            }
        }

        private string method_0(MemoryStream memoryStream_0)
        {
            byte[] array = new byte[2];
            memoryStream_0.Read(array, 0, 2);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(array);
            }
            short num = BitConverter.ToInt16(array, 0);
            byte[] array2 = new byte[(int)num];
            memoryStream_0.Read(array2, 0, (int)num);
            Encoding utf = Encoding.UTF8;
            return utf.GetString(array2);
        }

        private void method_1(string outputPath, List<ArcEntry> list, MemoryStream ms, LoadingForm lf)
        {
            long fileLength = ms.Length;
            int totalFiles = list.Count;

            for (int i = 0; i < totalFiles; i++)
            {
                ArcEntry arcEntry = list[i];

                if (arcEntry.Pos < 0 ||
                    arcEntry.Size <= 0 ||
                    arcEntry.Pos + arcEntry.Size > fileLength)
                {
                    continue;
                }

                try
                {
                    string fullPath = Path.Combine(outputPath, arcEntry.Name);
                    string directory = Path.GetDirectoryName(fullPath);
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                    ms.Position = arcEntry.Pos;
                    byte[] data = new byte[arcEntry.Size];
                    ms.Read(data, 0, arcEntry.Size);

                    FileUtils.WriteFile(data, fullPath);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show($"Permission denied: Could not write {arcEntry.Name}. Try running the app in Administrator");
                    return;
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"File Error: {ex.Message}");
                    return;
                }
                int percent = (int)((i / (double)totalFiles) * 100);
                lf.UpdateStatus("Extracting " + arcEntry.Name, percent);
            }
 
            lf.UpdateStatus("Extraction complete", 100);
        }

        public void BuildArchive(string arcPath, string workingPath)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    List<ArcEntry> list = new List<ArcEntry>();
                    List<string> list2 = method_4(workingPath);
                    foreach (string text in list2)
                    {
                        byte[] array = FileUtils.smethod_0(text);
                        if (array == null)
                            continue;
                        int size = array.Length;
                        int pos = (int)memoryStream.Position;
                        string name = text.Substring(workingPath.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                        memoryStream.Write(array, 0, array.Length);
                        list.Add(new ArcEntry(name, size, pos));
                    }

                    using (MemoryStream memoryStream2 = method_3(list))
                    {
                        int headerSize = (int)memoryStream2.Length;
                        foreach (ArcEntry entry in list)
                        {
                            entry.Pos += headerSize;
                        }
                    }

                    using (MemoryStream memoryStream3 = method_3(list))
                    {
                        GetInt16(arcPath, memoryStream3, memoryStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: ", ex.Message);
            }

        }

        private void GetInt16(string outputPath, MemoryStream header, MemoryStream data)
        {
            if (File.Exists(outputPath))
            {
                File.Copy(outputPath, outputPath + ".bak", true);
            }
            using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(header.ToArray());
                bw.Write(data.ToArray());
                bw.Flush();
            }
        }

        private MemoryStream method_3(List<ArcEntry> list_0)
        {
            global::ArraySupport @class = new global::ArraySupport();
            MemoryStream memoryStream = new MemoryStream();

            @class.WriteIntToStream(list_0.Count, memoryStream);

            foreach (ArcEntry arcEntry in list_0)
            {
                @class.WriteStringToStream(arcEntry.Name, memoryStream);
                @class.WriteIntToStream(arcEntry.Pos, memoryStream);
                @class.WriteIntToStream(arcEntry.Size, memoryStream);
            }
            return memoryStream;
        }

        private List<string> method_4(string string_0)
        {
            List<string> list = new List<string>();
            foreach (string item in Directory.GetFiles(string_0))
            {
                list.Add(item);
            }
            foreach (string string_ in Directory.GetDirectories(string_0))
            {
                list.AddRange(method_4(string_));
            }
            return list;
        }

        private static int ReadInt32BE(BinaryReader br)
        {
            var bytes = br.ReadBytes(4);
            if (bytes.Length != 4)
                throw new EndOfStreamException("Could not read 4 bytes for int32");
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        private static short ReadInt16BE(BinaryReader br)
        {
            var bytes = br.ReadBytes(2);
            Array.Reverse(bytes);
            return BitConverter.ToInt16(bytes, 0);
        }

        private static void WriteInt32BE(BinaryWriter bw, int value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            bw.Write(bytes);
        }

        private static void WriteInt16BE(BinaryWriter bw, short value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            bw.Write(bytes);
        }

        public static void RepairArchive(string arcPath, LoadingForm lf)
        {
            if (!File.Exists(arcPath))
                throw new FileNotFoundException("Archive not found.");

            string backupPath = arcPath + ".bak";
            File.Copy(arcPath, backupPath, true);

            lf.UpdateStatus("Opening archive...", 5);

            List<Tuple<string, byte[]>> validFiles = new List<Tuple<string, byte[]>>();

            using (FileStream fs = new FileStream(arcPath, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                long fileLength = fs.Length;

                int fileCount = ReadInt32BE(br);

                List<Tuple<string, int, int>> entries = new List<Tuple<string, int, int>>();

                for (int i = 0; i < fileCount; i++)
                {
                    short nameLen = ReadInt16BE(br);
                    string name = Encoding.UTF8.GetString(br.ReadBytes(nameLen));
                    int offset = ReadInt32BE(br);
                    int size = ReadInt32BE(br);

                    entries.Add(new Tuple<string, int, int>(name, offset, size));
                }

                for (int i = 0; i < entries.Count; i++)
                {
                    string name = entries[i].Item1;
                    int offset = entries[i].Item2;
                    int size = entries[i].Item3;

                    int percent = 30 + (int)((i / (double)entries.Count) * 40);
                    lf.UpdateStatus("Checking " + name, percent);
                    Thread.Sleep(50);

                    if (offset < 0 || size <= 0 || offset + size > fileLength)
                        continue;

                    fs.Position = offset;
                    byte[] data = br.ReadBytes(size);

                    if (data.Length == size)
                        validFiles.Add(new Tuple<string, byte[]>(name, data));
                }
            }

            lf.UpdateStatus("Rebuilding archive...", 75);
            Thread.Sleep(50);

            using (FileStream fs = new FileStream(arcPath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                WriteInt32BE(bw, validFiles.Count);

                long tableSize = 4;

                for (int i = 0; i < validFiles.Count; i++)
                {
                    tableSize += 2 + Encoding.UTF8.GetByteCount(validFiles[i].Item1) + 4 + 4;
                }

                long currentOffset = tableSize;

                for (int i = 0; i < validFiles.Count; i++)
                {
                    string name = validFiles[i].Item1;
                    byte[] data = validFiles[i].Item2;

                    int percent = 75 + (int)((i / (double)validFiles.Count) * 20);
                    lf.UpdateStatus("Rewriting " + name, percent);
                    Thread.Sleep(50);

                    byte[] nameBytes = Encoding.UTF8.GetBytes(name);

                    WriteInt16BE(bw, (short)nameBytes.Length);
                    bw.Write(nameBytes);
                    WriteInt32BE(bw, (int)currentOffset);
                    WriteInt32BE(bw, data.Length);

                    currentOffset += data.Length;
                }

                for (int i = 0; i < validFiles.Count; i++)
                {
                    bw.Write(validFiles[i].Item2);
                }
            }

            lf.UpdateStatus("Repair complete", 100);
        }

        public ArchiveWorker()
		{
			ArrSupport = new ArraySupport();
		}

		private ArraySupport ArrSupport;
	}
}
