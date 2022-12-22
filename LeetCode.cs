public class Solution {
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
    
    public int Reverse(int x) {
        try{
            bool isNegative = x < 0;

            Stack<char> pila = new Stack<char>();
            string numero = x.ToString();

            int index = isNegative ? 1 : 0;

            for(int i = index; i < numero.Length ; i++){
                pila.Push(numero[i]);
            }
            numero = "";
            while(pila.Count > 0){
                numero += pila.Pop();
            }
            int result = Int32.Parse(numero);

            return isNegative ? (-1) * result : result;
        }catch(Exception ex){ //Caso de que sea > Int32
            return 0;
        }
    }
}
