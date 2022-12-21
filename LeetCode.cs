public class AddTwoNumbersSolution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        string a = ""; 
        string b = "";

        while(l1 != null){
            a = l1.val + a;
            l1 = l1.next;
        }

        while(l2 != null){
            b = l2.val + b;
            l2 = l2.next;
        }
        var res = (BigInteger.Parse(b) + BigInteger.Parse(a));
        var suma = (res).ToString();

        ListNode result = new ListNode();
        var aux = result; 

        for(int i = suma.Length - 1; i >= 0; i--){
            aux.val = (int)(suma[i] - '0');

            if(i != 0){
                aux.next = new ListNode();
                aux = aux.next;
            }
        }
        return result;
    }
}
