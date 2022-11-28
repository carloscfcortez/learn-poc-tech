package main

import (
	"fmt"
	"bufio"
	"os"
)

func main() {
	

	reader := bufio.NewReader(os.Stdin)
	fmt.Print("Enter text: ")
	text, _ := reader.ReadString('\n')
	fmt.Println("You entered: ", text)
}
