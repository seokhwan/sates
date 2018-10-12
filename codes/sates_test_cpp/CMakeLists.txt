SET(GCC "yes")
#SET(VC "yes")

cmake_minimum_required(VERSION 3.8.0)
project(sates_test_cpp CXX)

file(GLOB sates_file ${CMAKE_SOURCE_DIR}/sates/*)
source_group(sates FILES ${sates_file})

file(GLOB internal_use_file ${CMAKE_SOURCE_DIR}/sates/internal_use/*)
source_group(sates\\internal_use FILES ${internal_use_file})

file(GLOB os_file ${CMAKE_SOURCE_DIR}/sates/os/*)
source_group(sates\\os FILES ${os_file})

if (GCC)
	file(GLOB os_dept_file ${CMAKE_SOURCE_DIR}/sates/os/linux/*)
	source_group(sates\\os\\linux FILES ${os_dept_file})
endif()

if (VC)
	file(GLOB os_dept_file ${CMAKE_SOURCE_DIR}/sates/os/win/*)
	source_group(sates\\os\\win FILES ${os_dept_file})
endif()

include_directories(${CMAKE_SOURCE_DIR})

add_executable(sates_test_cpp ${sates_file} ${internal_use_file} ${os_file} ${os_dept_file} main.cpp)

if (GCC)
	target_link_libraries(sates_test_cpp pthread)
endif()