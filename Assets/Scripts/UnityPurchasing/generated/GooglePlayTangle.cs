// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("3Rr3JwyGIGQ7zsGg34epjEd3N6AcuenqFETUTiBUB5IKQDO+rmxwbLW8P/IjwmUJ4lbyUQcgxXc0Sz0ZoWojCaz/SqBUwLevxjWsignPabkUwUGZdeVe5wDFziDRS9lRl5+dM25xj/9Fa+0vmsgwPGFj/CSb5O5wXNF/JJ/e9F1J5CnkSCuX8gQvixaYKqmKmKWuoYIu4C5fpampqa2oq+6IN2Ty9DR6FswA64xwxhJrpNXIdbxX+9BD3AZjSv7qbbydawENgqidj7dPLQoHKB1xehaS6yzJzlRY0/jbuoajLkVkZnV7x531A7VISx99KqmnqJgqqaKqKqmpqGezZ1UAOih9MXmUhiaxxed8t7EV8pjLlsFT+/OqIu2fiXGV86qrqaip");
        private static int[] order = new int[] { 2,4,9,6,11,12,13,9,9,10,10,12,12,13,14 };
        private static int key = 168;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
