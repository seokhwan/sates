#include <iostream>
#include <sates/sates_test_cpp.h>
#include <sates/os/tcp_client.h>
#include <sates/os/sleep.h>
#include <string.h>

SATES_TEST_INIT(TEST)
{
	SATES_TRUE(false);
}

SATES_TEST_RUN(TEST)
{
	std::cout << "TEST 000000000" << std::endl;
}

SATES_TEST_TERMINATE(TEST)
{

}

SATES_TEST_INIT(TEST2)
{

}

SATES_TEST_RUN(TEST2)
{
	SATES_TRUE(false);
	SATES_TRUE(false);
	SATES_TRUE(false);
	std::cout << "TEST 2222222222" << std::endl;
}

SATES_TEST_TERMINATE(TEST2)
{

}

SATES_TEST_INIT(TEST3)
{

}

SATES_TEST_RUN(TEST3)
{
	std::cout << "TEST 3333333333" << std::endl;
}

SATES_TEST_TERMINATE(TEST3)
{
	//SATES_TRUE(false);
}

int main(int argc, char** argv)
{
	//sates::test_list::include_test("TEST");
	sates::testcode_list::run();
	//SATES_TEST_RUN_MAIN_FUNC_RUN(TEST);
	sates::os::tcp_client client;
	client.connect("192.168.100.234", "192.168.100.234", 5000);
	char buffer[1024];
	int count = 0;
	while (true)
	{
		count++;
		memset(buffer, 0, 1024);
		sprintf(buffer, "test message %d\n", count);
		client.write((const int8_t*)buffer, 1024);
		sates::os::sleep(3000 * 1000);
	}
	
	sates::testcode_list::print_result();
	return 0;
}
