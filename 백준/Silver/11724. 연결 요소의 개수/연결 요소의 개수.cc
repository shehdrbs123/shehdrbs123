// 3위 분꺼 Test
#include <cstdio>

short par[1001];
short Find(int x) { return x == par[x] ? x : par[x] = Find(par[x]); }
bool Union(int a, int b) { a = Find(a), b = Find(b), par[b] = a; return a != b; }

int main() {
	auto readInt = [&]() {
		int ret = 0;
        for (char c = getchar(); c & 16; ret = 10 * ret + (c & 15), c = getchar());
		return ret;
	};
    
	int n = readInt(), m = readInt(), cnt = n;
    for (int i = 0; i <= 1000; i++) par[i] = i;
    for (; m-- && cnt > 1; cnt -= Union(readInt(), readInt()));
    printf("%d\n", cnt);
}