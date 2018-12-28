package SynchronizingMethods;

public class demo {
    public void WithDrawAmount(int num) {
        synchronized (this) {
            System.out.println("hello world");
        }
    }

    public synchronized void WithDrawAmount()
    {
        System.out.println("hello world");
    }
}
