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
    
    public int[] PlusOne(int[] digits) {
        var str = (Int32.Parse(String.Join(string.Empty, digits)) + 1).ToString();
        List<int> result = new List<int>();

        for(int i = 0; i < str.Length ;i++){
            result.Add(Int32.Parse(str[i].ToString()));
        }
        
        return result.ToArray();
    }
    
    public int MySqrt(int x) {
        return Convert.ToInt32(Math.Floor(Math.Sqrt(x)));
    }
    
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode aux = head;
        while(aux != null && aux.next != null){
            if(aux.val == aux.next.val){
                aux.next = aux.next.next;
            }else{
                aux = aux.next;
            }
        }
        return head;
    }
    
    public int LengthOfLastWord(string s) {
        String[] strlist = s.Trim().Split(' ');
        return strlist[strlist.Length - 1].Length;
    }
    
    public bool HasCycle(ListNode head) {
        Dictionary<int, bool> values = new Dictionary<int, bool>();
        if(head == null) return false;
        ListNode aux = head;

        while(aux != null){
            if(values.ContainsKey(aux.val)){
                return true;
            }else{
                values.Add(aux.val, true);
            }
            aux = aux.next;
        }
        return false;
    }
    
    public int SingleNumber(int[] nums) {
        Dictionary<int, int> values = new Dictionary<int, int>();

        foreach(var number in nums){
            if(values.ContainsKey(number)){
                values[number] = values[number] + 1;
            }else{
                values[number] = 1;
            }
        }
        int valor = 0;
        
        foreach(KeyValuePair<int, int> entry in values)
        {
            if(values[entry.Key] == 1){
                valor = entry.Key;
            }
        }
        return valor;
    }
    
    public bool IsPalindrome(string s) {
        string result = "";
        for(int i = 0; i < s.Length; i++){
            if(Regex.IsMatch(s[i].ToString(), @"^[a-zA-Z0-9]+$")) result += s[i];
        }

        result = result.ToLower();

        for(int j = 0; j < Math.Floor((double)result.Length/2) ;j++){
            if(result[j] != result[result.Length - 1 - j]) return false;
        }

        return true;
    }
    
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> res = new List<int>();
        PreorderTraversalAux(root, res);
        return res;
    }

    public void PreorderTraversalAux(TreeNode root, List<int> aux) {
        if(root != null){
            aux.Add(root.val);
            PreorderTraversalAux(root.left, aux);
            PreorderTraversalAux(root.right, aux);
        }
    }
    
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> res = new List<int>();
        PostorderTraversalAux(root, res);
        return res;
    }

    public void PostorderTraversalAux(TreeNode root, List<int> aux) {
        if(root != null){
            PostorderTraversalAux(root.left, aux);
            PostorderTraversalAux(root.right, aux);
            aux.Add(root.val);
        }
    }
    
    public ListNode RemoveElements(ListNode head, int val) {
        while (head != null && head.val == val) { //Me muevo todos para adelante si es necesario
            head = head.next;
        }

        if (head == null) { //Si es null return null
            return null;
        }

        var aux = head; //Auxiliar
        while(aux.next != null){
            ListNode iter = aux.next; //El siguiente ya que es no null

            if(iter.val == val){
                aux.next = iter.next;
            }else{
                aux = aux.next;
            }
        }
        return head;
    }
    
    public ListNode ReverseList(ListNode head) {
        ListNode newHead = null;
            while(head!=null)
            {
                ListNode next = head.next;
                head.next = newHead;
                newHead = head;
                head = next;
            }
            return newHead;
    }
    
    public bool ContainsDuplicate(int[] nums) {
        Dictionary<int, int> values = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            if(values.ContainsKey(nums[i])){
                return true;
            }else{
                values[nums[i]] = 1;
            }
        }
        return false;
    }
    
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        foreach(var num in nums){
            var i = Array.LastIndexOf(nums, num);
            var j = Array.IndexOf(nums, num);
            if(i == j && Math.Abs(i - j) <= k){
                return true;
            }
        }
        return false;
    }
    
    public bool IsValid(string s) {
        int i = 0;
        bool correcto = true;

        List<char> entradas = new List<char>(){
            '(','[','{'
        };

        List<char> salidas = new List<char>() {
            ')',']','}'
        };

        var pila = new Stack<char>();

        while(correcto && i < s.Length){
            Console.WriteLine(s[i]);
            if(entradas.Contains(s[i])){
                pila.Push(s[i]);
            }else if(salidas.Contains(s[i])){
                if(pila.Count > 0){
                    var ultimo = pila.Peek();
                    if((ultimo == '(' && s[i] == ')') || (ultimo == '[' && s[i] == ']') || (ultimo == '{' && s[i] == '}')){
                        pila.Pop();
                    }else{
                        correcto = false;
                    }
                }else{
                    correcto = false;
                }
            }
            i++;
        }
        return correcto && (pila.Count == 0);
    }
    
    public TreeNode createBST(int[] nums, int start, int end){
        if(start > end){
            return null;
        }
        int mid = start + (end-start)/2;
        TreeNode node = new TreeNode(nums[mid]);
        
        node.left = createBST(nums, start, mid - 1);
        node.right = createBST(nums, mid + 1, end);
        
        return node;
    }

    public TreeNode SortedArrayToBST(int[] nums) {
        return createBST(nums, 0, nums.Length - 1);
    }
}
