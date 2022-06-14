package main

import (
	"strings"

	"golang.org/x/tour/wc"
)

func WordCount(s string) map[string]int {
	stringSlice := make(map[string]int)

	words := strings.Fields(s)

	for _, v := range words {
		stringSlice[v]++

	}
	return stringSlice
}
func main() {
	wc.Test(WordCount)
}
