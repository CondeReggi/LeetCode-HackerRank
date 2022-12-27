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
    
    public int MyAtoi(string s) {
        s = s.Trim();

        if(s.Length == 0) return 0;

        int result = 0;
        int counter = 0;
        bool isNegative = false;
        for(int i = 0; i < s.Length; i++){
            int number;
            if(s[i].ToString() == "-") isNegative = true;

            if(int.TryParse(s[i].ToString(), out number)){
                result = (result * 10) + number;
                counter++;
            }
        }
        return isNegative ? -result : result;
    }
    
    public int RomanToInt(string s) {
        Dictionary<string, int> valores = Diccionario();
        int sum = 0;
        for(int i = 0; i < s.Length ; i++){
            char currentRomanChar = s[i];

            if (i + 1 < s.Length && valores[s[i + 1].ToString()] > valores[currentRomanChar.ToString()])
            {
                sum -= valores[currentRomanChar.ToString()];
            }
            else
            {
                sum += valores[currentRomanChar.ToString()];
            }
        }
        return sum;
    }

    public Dictionary<string, int> Diccionario(){
        Dictionary<string, int> valores = new Dictionary<string, int>();
        valores.Add("I",1);
        valores.Add("V",5);
        valores.Add("X",10);
        valores.Add("L",50);
        valores.Add("C",100);
        valores.Add("D",500);
        valores.Add("M",1000);
        return valores;
    }
    
    public string LongestCommonPrefix(string[] strs) {
        string result = "";
        var minimo = strs.ToList().Select(x => x.Length).Min();

        for(int i = 0; i < minimo; i++){
            bool esta_en_todos = true;
            char value = strs[0][i];

            for(int j = 0; j < strs.Length; j++){
                if(value != strs[j][i]){
                    esta_en_todos = false;
                    break;
                }
            }
            if(esta_en_todos){
                result += strs[0][i].ToString();
            }else{
                break;
            }
        }
        return result;
    }
    
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if(q == null && p != null) return false;
        if(p == null && q != null) return false;
        if(q == null && p == null) return true;
        
        if(p.val != q.val) return false;

        bool left = IsSameTree(p.left , q.left);
        bool right = IsSameTree(p.right , q.right);

        return left && right;
    }
    
    public bool IsSymmetric(TreeNode root) {
        if(root.left == null && root.right != null) return false;
        if(root.left != null && root.right == null) return false;

        return CompareTwoTrees(root.left, root.right);
    }

    public bool CompareTwoTrees(TreeNode one, TreeNode two){
        if(one == null && two == null) return true;

        if(one.val != two.val) return false;

        if(one.left == null && two.right != null) return false;
        if(one.left != null && two.right == null) return false;
        if(one.right == null && two.left != null) return false;
        if(one.right != null && two.left == null) return false;

        return CompareTwoTrees(one.left, two.right) && CompareTwoTrees(one.right, two.left);
    }
    
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;
        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
    
    public List<int> InorderTraversal(TreeNode root) {
        List<int> res = new List<int>();
        InorderTraversalAux(root, res);

        return res;
    }

    public void InorderTraversalAux(TreeNode root, IList<int> aux){
        if(root == null) return;

        InorderTraversalAux(root.left, aux);
        aux.Add(root.val);
        InorderTraversalAux(root.right, aux);
    }
    
    
}
