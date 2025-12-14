package edu.itvo.mygestordefinanzas.presentacion.navigation

import androidx.compose.runtime.Composable
import androidx.hilt.navigation.compose.hiltViewModel
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import edu.itvo.mygestordefinanzas.presentacion.ui.screens.AddTransactionScreen
import edu.itvo.mygestordefinanzas.presentacion.ui.screens.MainScreen
import edu.itvo.mygestordefinanzas.presentacion.viewmodel.MainViewModel
import edu.itvo.mygestordefinanzas.presentacion.ui.screens.AddTransactionScreen
import edu.itvo.mygestordefinanzas.presentacion.ui.screens.MainScreen
import edu.itvo.mygestordefinanzas.presentacion.viewmodel.TransactionViewModel


@Composable
fun MainNavGraph(
    navController: NavHostController
) {
    NavHost(
        navController = navController,
        startDestination = Routes.MAIN
    ) {

        composable(Routes.MAIN) {
            val mainViewModel: MainViewModel = hiltViewModel()

            MainScreen(
                viewModel = mainViewModel,
                onAddTransaction = {
                    navController.navigate(Routes.ADD_TRANSACTION)
                }
            )
        }

        composable(Routes.ADD_TRANSACTION) {
            val transactionViewModel: TransactionViewModel = hiltViewModel()

            AddTransactionScreen(
                onSave = {
                    transactionViewModel.add(it)
                    navController.popBackStack()
                },
                onCancel = {
                    navController.popBackStack()
                }
            )
        }
    }
}