package edu.itvo.mygestordefinanzas.presentacion


import androidx.compose.runtime.*
import androidx.hilt.navigation.compose.hiltViewModel
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import edu.itvo.mygestordefinanzas.presentacion.ui.screens.AddTransactionScreen
import edu.itvo.mygestordefinanzas.presentacion.ui.screens.MainScreen
import edu.itvo.mygestordefinanzas.presentacion.viewmodel.MainViewModel
import edu.itvo.mygestordefinanzas.presentacion.viewmodel.TransactionViewModel
import edu.itvo.mygestordefinanzas.ui.theme.MyGestorDeFinanzasTheme

@Composable
fun MyGestorDeFinanzasApp(
    mainViewModel: MainViewModel = hiltViewModel()
) {
    val preferences by mainViewModel
        .userPreferences
        .collectAsState()
    val transactionViewModel: TransactionViewModel = hiltViewModel()

    val navController = rememberNavController()

    MyGestorDeFinanzasTheme(
        darkTheme = preferences.darkTheme
    ) {
        NavHost(
            navController = navController,
            startDestination = "main"
        ) {

            composable("main") {
                MainScreen(
                    viewModel = mainViewModel,
                    onAddTransaction = {
                        navController.navigate("add_transaction")
                    }
                )
            }

            composable("add_transaction") {
                AddTransactionScreen(
                    onSave = { transaction ->
                        transactionViewModel.add(transaction)
                        navController.popBackStack()
                    },
                    onCancel = {
                        navController.popBackStack()
                    }
                )
            }

        }
    }
}
