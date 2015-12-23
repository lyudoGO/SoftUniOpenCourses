1 /* 
2  * Write a program that reads a text file and inserts line numbers in front of 
3  * each of its lines. The result should be written to another text file.
4  */
5 #include <stdio.h>
6 #include <stdlib.h>
7 
8 int main(int argc, char** argv) 
9 {
10     FILE *sourceFile = fopen("main.c", "r");
11     if (!sourceFile) 
12     {
13         return 1;
14     }
15     FILE *destFile = fopen("modified-main.c", "w");
16     if (!destFile) 
17     {
18         return 1;
19     }
20     
21     char *line = NULL;
22     size_t size = 0, number = 1;;
23     while (!feof(sourceFile))
24     {
25         size_t length = getline(&line, &size, sourceFile);
26         fprintf(destFile, "%d %s", number, line);
27         number++;
28     }
29     free(line);
30     fclose(sourceFile);
31     fclose(destFile);
32 
33     return (EXIT_SUCCESS);
34 }