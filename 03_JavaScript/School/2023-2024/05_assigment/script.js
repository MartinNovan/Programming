function palindrome() {
    let input = document.getElementById("input").value
    containsSpecialCharacters(input)
}
function containsSpecialCharacters(input) {
    const specialCharRegex = /[ěščřžýáíé]/i;
    if(specialCharRegex.test(input))
        {
            alert('Warning: The input contains special characters!');
            document.getElementById('output').textContent = 'is it a palindrome: N/A';
        } else {
            let cleanedStr = input.replace(/[^A-Za-z0-9]/g, '').toLowerCase();
            let reversedStr = cleanedStr.split('').reverse().join('');
            console.log(reversedStr)
            if(reversedStr === cleanedStr){
                document.getElementById('output').textContent = 'is it a palindrome: Yes';
            } else{
                document.getElementById('output').textContent = 'is it a palindrome: No';   
            }
        }
}