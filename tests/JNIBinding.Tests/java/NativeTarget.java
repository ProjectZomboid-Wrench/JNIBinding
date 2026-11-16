public class NativeTarget {
    public static native int add(int a, int b);

    public static int callAdd(int a, int b) {
        return add(a, b);
    }
}
